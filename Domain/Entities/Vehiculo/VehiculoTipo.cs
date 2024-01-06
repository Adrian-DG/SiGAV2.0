using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Vehiculo;

namespace Domain.Entities
{
    [Table(name: "VehiculoTipos", Schema = "Vehiculo")]
    public class VehiculoTipo : NamedEntityMetadata
    {
        public ICollection<VehiculoPlaca>? VehiculoPlacas { get; set; }
    }
}