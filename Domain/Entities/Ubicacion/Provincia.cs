using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provincia : NamedEntityMetadata
    {
        public RegionMacro RegionMacro { get; set; }
    }
}