using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public abstract class EntityMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion 
        { 
            get => this.FechaCreacion;
            set => FechaCreacion = GetActualDateTime(); 
        }

        [DataType(DataType.DateTime)]
        public DateTime FechaModificacion { get; set; }
        public bool Estatus { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime GetActualDateTime() => DateTime.UtcNow;

    }
}