using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Vehiculo
{
    [Table(name: "VehiculoPlacas", Schema = "Vehiculo")]
    public class VehiculoPlaca : EntityMetadata
    {
        public string? Sigla { get; set; }
        public string? Descripcion { get; set; }
        public TipoPlaca TipoPlaca { get; set; }
    }
}