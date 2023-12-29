using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Unidad
{
    [Table(name: "HistoricoUnidades", Schema = "Unidad")]
    public class HistoricoUnidad : EntityMetadata
    {
        [ForeignKey("Denominacion")]
        public int DenominacionId { get; set; } 
        public virtual Denominacion? Denominacion { get; set; }

        [ForeignKey("TipoUnidad")]
        public int TipoUnidadId { get; set; }
        public virtual TipoUnidad? TipoUnidad { get; set; }     

        [ForeignKey("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad? Unidad { get; set; }  
    }
}