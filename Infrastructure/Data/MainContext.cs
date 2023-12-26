using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.Entities;
using Domain.Entities.Asistencias;
using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Asistencia>()
                .Property(prop => prop.TipoAsistencias)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<TipoAsistencia>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<Asistencia>()
                .Property(prop => prop.Imagenes)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<string>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<VehiculoPlaca>()
                .Property(prop => prop.TipoVehiculo)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<IList<VehiculoTipo>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            modelBuilder.Entity<EntityMetadata>().HasQueryFilter(prop => !prop.IsDeleted);

            // RegisterEntities<EntityMetadata>(modelBuilder, AppDomain.CurrentDomain.GetAssemblies());
            // https://stackoverflow.com/questions/38854269/dynamically-loading-dbset-to-dbcontext
            // https://stackoverflow.com/questions/851248/c-sharp-reflection-get-all-active-assemblies-in-a-solution
            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(x => x.GetExportedTypes())
                        .Where(c => 
                            c.IsClass 
                            && !c.IsAbstract 
                            && c.IsPublic 
                            && typeof(EntityMetadata).IsAssignableFrom(c)
                        );
            
            foreach(var type in types) 
            {
                modelBuilder.Entity(type);
            }

            base.OnModelCreating(modelBuilder);
        }


    }
}