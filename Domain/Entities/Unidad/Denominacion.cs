using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Unidad
{
    public class Denominacion : NamedEntityMetadata
    {
        [ForeignKey("TipoUnidad")]
        public int TipoUnidadId { get; set; }
        public virtual TipoUnidad? TipoUnidad { get; set; }  
        
        [ForeignKey("Tramo")]
        public int TramoId { get; set; }
        public virtual Tramo? Tramo { get; set; }
    }
}