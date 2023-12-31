using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "VehiculoModelos", Schema = "Vehiculo")]
    public class VehiculoModelo : NamedEntityMetadata
    {
        [ForeignKey("VehiculoMarcaId")]
        public int VehiculoMarcaId { get; set; }
        public virtual VehiculoMarca? VehiculoMarca{ get; set; }

        [ForeignKey("VehiculoTipoId")]
        public int VehiculoTipoId { get; set; }
        public virtual VehiculoTipo? VehiculoTipo { get; set; }
    }
}