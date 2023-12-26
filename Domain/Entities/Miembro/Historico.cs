using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Miembro
{
    [Table(name: "Historico", Schema = "Miembro")]
    public class Historico : EntityMetadata
    {
        [ForeignKey("Rango")]
        public int  RangoId { get; set; }
        public virtual Rango? Rango { get; set; }
        public Institucion Institucion { get; set; }

        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public virtual Miembro? Miembro { get; set; }
    }
}