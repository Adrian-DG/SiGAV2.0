using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Vehiculo
{
    public class VehiculoPlaca : EntityMetadata
    {
        public string? Sigla { get; set; }
        public TipoPlaca TipoPlaca { get; set; }
        public IList<VehiculoTipo>? TipoVehiculo { get; set; }
    }
}