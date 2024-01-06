using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Unidad
{
    [Table(name: "Denominaciones", Schema = "Unidad")]
    public class Denominacion : NamedEntityMetadata
    {        
        [ForeignKey("Tramo")]
        public int TramoId { get; set; }
        public virtual Tramo? Tramo { get; set; }
    }
}