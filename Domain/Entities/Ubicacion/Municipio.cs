using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Municipio : NamedEntityMetadata
    {
        [ForeignKey("ProvinciaId")]
        public int ProvinciaId { get; set; }
        public virtual Provincia? Provincia { get; set; }
    }
}