using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Usuario;

namespace Domain.Abstraction
{
    public abstract class AuditableEntity : EntityMetadata
    {
        [ForeignKey("Creador")]
        public string? CreadorId { get; set; }
        public virtual Usuario? Creador { get; set; }

        [ForeignKey("Editor")]
        public string? EditorId { get; set; }
        public virtual Usuario? Editor { get; set; }
    }
}