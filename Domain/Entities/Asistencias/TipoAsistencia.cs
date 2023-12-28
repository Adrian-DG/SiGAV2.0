using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Asistencia
{
    [Table(name: "TipoAsistencias", Schema = "Asistencias")]
    public class TipoAsistencia : NamedEntityMetadata
    {
        public CategoriaAsistencia CategoriaAsistencia { get; set; }
    }
}