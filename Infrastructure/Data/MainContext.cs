using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.Entities;
using Domain.Entities.Asistencia;
using Domain.Entities.Departamento;
using Domain.Entities.Miembro;
using Domain.Entities.Unidad;
using Domain.Entities.Usuario;
using Domain.Entities.Vehiculo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class MainContext : IdentityDbContext<Usuario>
    {
        #region Entities

        #region Miscelaneos
        public DbSet<Departamento>? Departamentos { get; set; }

        #endregion

        #region Unidad
        public DbSet<TipoUnidad>? TipoUnidades { get; set; }
        public DbSet<HistoricoUnidad>? HistoricoUnidades { get; set; }
        public DbSet<Denominacion>? Denominaciones { get; set; }

        #endregion

        #region Miembro
            
        public DbSet<Rango>? Rangos { get; set; }
        public DbSet<Miembro>? Miembros { get; set; }
        public DbSet<HistoricoMiembro>? HistoricoMiembros { get; set; }

        #endregion
       
        #region Vehiculo

        public DbSet<VehiculoPlaca>? VehiculoPlacas { get; set; }
        public DbSet<VehiculoColor>? VehiculoColores { get; set; }
        public DbSet<VehiculoTipo>? VehiculoTipos { get; set; }
        public DbSet<VehiculoMarca>? VehiculoMarcas { get; set; }
        public DbSet<VehiculoModelo>? VehiculoModelos { get; set; }

        #endregion

        #region Ubicacion        
        public DbSet<RegionAsistencia>? RegionAsistencias { get; set; }
        public DbSet<Tramo>? Tramos { get; set; }
        public DbSet<Provincia>? Provincias { get ; set; }
        public DbSet<Municipio>? Municipios { get; set; }
        
        #endregion

        #region Asistencia
            
        public DbSet<TipoAsistencia>? TipoAsistencias { get; set; }
        public DbSet<HistoricoAsistencia>? HistoricoAsistencias { get; set; }
        public DbSet<Asistencia>? Asistencias { get; set; }

        #endregion

        #endregion

        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies(); // enables LazyLoading on virtual properties
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes().Where(c => c.ClrType.IsAssignableTo(typeof(EntityMetadata)));

            Expression<Func<EntityMetadata, bool>> filterExpression = x => !x.IsDeleted;

            foreach (var entity in entities)
            {
                var parameter = Expression.Parameter(entity.ClrType);
                var body = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.First(), parameter, filterExpression.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);
                entity.SetQueryFilter(lambdaExpression);
            }

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

            // modelBuilder.Entity<VehiculoPlaca>()
            //     .Property(prop => prop.TipoVehiculo)
            //     .HasConversion(
            //         v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            //         v => JsonConvert.DeserializeObject<IList<VehiculoTipo>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
            //     );

            modelBuilder.Entity<Miembro>().HasIndex(i => i.Cedula).IsUnique();

            modelBuilder.Entity<Unidad>().HasIndex(i => i.Ficha).IsUnique();

            base.OnModelCreating(modelBuilder);
        }


    }
}