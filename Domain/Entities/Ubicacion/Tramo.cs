using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tramo : NamedEntityMetadata
    {
        [ForeignKey("RegionAsistenciaId")]
        public int RegionAsistenciaId { get; set; }
        public virtual RegionAsistencia? RegionAsistencia { get; set; }
    }
}