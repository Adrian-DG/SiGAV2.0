using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "Rangos", Schema = "Miembro")]
    public class Rango : NamedEntityMetadata
    {
        public string? NombreArmada { get; set; }
    }
}