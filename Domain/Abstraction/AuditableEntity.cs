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
        public Guid CreadorId { get; set; }
        public Usuario? Creador { get; set; }

        [ForeignKey("Editor")]
        public Guid EditorId { get; set; }
        public Usuario? Editor { get; set; }
    }
}