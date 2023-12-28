using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Miembro
{
    public class Historico : EntityMetadata
    {
        [ForeignKey("Rango")]
        public int  RangoId { get; set; }
        public virtual Rango? Rango { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento.Departamento? Departamento { get; set; }

        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public virtual Miembro? Miembro { get; set; }
        public Institucion Institucion { get; set; }

    }
}