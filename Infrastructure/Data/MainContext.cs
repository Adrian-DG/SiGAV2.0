using System;
using System.Collections.Generic;
using System.Linq;
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
using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class MainContext : DbContext
    {
        #region Entities

        #region Miscelaneos
        public DbSet<Departamento>? Departamentos { get; set; }

        #endregion

        #region Unidad
        public DbSet<TipoUnidad>? TipoUnidades { get; set; }
        public DbSet<Domain.Entities.Unidad.Historico>? HistoricoUnidades { get; set; }
        public DbSet<Denominacion>? Denominaciones { get; set; }

        #endregion

        #region Miembro
            
        public DbSet<Rango>? Rangos { get; set; }
        public DbSet<Miembro>? Miembros { get; set; }
        public DbSet<Domain.Entities.Miembro.Historico>? HistoricoMiembros { get; set; }

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
        public DbSet<Domain.Entities.Asistencia.Historico>? HistoricoAsistencias { get; set; }
        public DbSet<Domain.Entities.Asistencia.Asistencia>? Asistencias { get; set; }

        #endregion

        #endregion

        public MainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies(); // enables LazyLoading on virtual properties
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

            modelBuilder.Entity<Miembro>().HasIndex(i => i.Cedula).IsUnique();

            modelBuilder.Entity<Unidad>().HasIndex(i => i.Ficha).IsUnique();

            modelBuilder.Entity<EntityMetadata>().HasQueryFilter(prop => !prop.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }


    }
}