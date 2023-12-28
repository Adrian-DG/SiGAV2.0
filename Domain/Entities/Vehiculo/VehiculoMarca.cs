using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "VehiculoMarcas", Schema = "Vehiculo")]
    public class VehiculoMarca : NamedEntityMetadata
    {
        
    }
}