using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public abstract class NamedEntityMetadata : EntityMetadata
    {
        public string? Name { get; set; }
    }
}