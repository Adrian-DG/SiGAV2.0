using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Unidad;

namespace Domain.Entities.Asistencia
{
    [Table(name: "Asistencias", Schema = "Asistencia")]
    public class Asistencia : AuditableEntity
    {
        // Ciudadano
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public Sexo Sexo { get; set; }
        public int Edad { get; set; }
        public bool EsExtranjero { get; set; }

        // Vehiculo

        [ForeignKey("VehiculoTipo")]
        public int VehiculoTipoId { get; set; }
        public virtual VehiculoTipo? VehiculoTipo { get; set; }

        [ForeignKey("VehiculoColor")]
        public int VehiculoColorId { get; set; }
        public virtual VehiculoColor? VehiculoColor { get; set; }
        
        [ForeignKey("VehiculoMarca")]
		public int VehiculoMarcaId { get; set; }
		public virtual VehiculoMarca? VehiculoMarca { get; set; }

		[ForeignKey("VehiculoModelo")]
		public int VehiculoModeloId { get; set; }
		public virtual VehiculoModelo? VehiculoModelo { get; set; }
        public TipoPlaca TipoPlaca { get; set; }
        public string? Placa { get; set; }

        // Ubicacion

        [ForeignKey("Provincia")]
		public int ProvinciaId { get; set; }
		public virtual Provincia? Provincia { get; set; }

        [ForeignKey("Municipio")]
		public int MunicipioId { get; set; }
		public virtual Municipio? Municipio { get; set; }
        public string? Direccion { get; set; }
        public string? Coordenadas { get; set; }

        [ForeignKey("Tramo")]
        public int TramoId { get; set; }
        public virtual Tramo? Tramo { get; set; }

        // Unidad 

        [ForeignKey("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad.Unidad? Unidad { get; set; }

        [ForeignKey("DenominacionId")]
        public int DenominacionId { get; set; }
        public virtual Denominacion? Denominacion { get; set; }

        [ForeignKey("TipoUnidad")]
        public int TipoUnidadId { get; set; }
        public virtual TipoUnidad? TipoUnidad { get; set; }

        // Agente

        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public virtual Miembro.Miembro? Miembro { get; set; }

        // Datos Asistencia

        public DateTime TiempoLlegada { get; set; }
        public DateTime TiempoCompletada { get; set; }
        public EstatusAsistencia EstatusAsistencia { get; set; }
        public CategoriaAsistencia CategoriaAsistencia { get; set; }
        public IList<TipoAsistencia>? TipoAsistencias { get; set; }
        public IList<string>? Imagenes { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string? Comentario { get; set; }        
        public ReportadoPor QuienReporto { get; set; }
        public bool FueReasignada { get; set; } = false;        
    }
}