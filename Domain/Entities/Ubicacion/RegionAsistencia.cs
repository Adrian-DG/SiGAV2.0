using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "RegionAsistencia", Schema = "Asistencias")]
    public class RegionAsistencia : NamedEntityMetadata
    {
        public PerteneceA PerteneceA { get; set; }
        public RegionMacro RegionMacro { get; set; }
    }
}