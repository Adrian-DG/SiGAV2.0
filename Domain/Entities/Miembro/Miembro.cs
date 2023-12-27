using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Miembro
{
    [Table(name: "Miembros", Schema = "Miembro")]
    public class Miembro : EntityMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public Sexo Sexo { get; set; }

        [ForeignKey("RangoId")]
        public int RangoId { get; set; }
        public virtual Rango? Rango { get; set; }
        public Institucion Institucion { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento.Departamento? Departamento { get; set; }
        public NivelAccesoMiembro NivelAcceso { get; set; }
        public bool Autorizado { get; set; } = false;
        public virtual ICollection<Historico>? Historicos { get; set; }
        public string InformacionMiembro() => $"{ (Institucion == Institucion.ARD ? Rango?.NombreArmada : Rango?.Name)  }, {Nombre} {Apellido}";
        public string ObtenerNivelDeAcceso() => NivelAcceso.ToString().Replace("_", " ");
    }
}