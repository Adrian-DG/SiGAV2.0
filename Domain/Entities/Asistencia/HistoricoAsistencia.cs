using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Asistencia
{
    [Table(name: "HistoricoAsistencias", Schema = "Asistencia")]
    public class HistoricoAsistencia : EntityMetadata
    {
        [ForeignKey("Unidad")]
        public int UnidadId { get; set; }
        public virtual Unidad.Unidad? Unidad { get; set; }

        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public virtual Miembro.Miembro? Miembro { get; set; }

        [ForeignKey("Asistencia")]
        public int AsistenciaId { get; set; }
        public virtual Asistencia? Asistencia { get; set; }
    }
}