using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Asistencia
{
    public class TipoAsistencia : NamedEntityMetadata
    {
        public CategoriaAsistencia CategoriaAsistencia { get; set; }
    }
}