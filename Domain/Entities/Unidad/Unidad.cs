using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Unidad
{
    [Table(name: "Unidades", Schema = "Unidad")]
    public class Unidad : EntityMetadata
    {
        public string? Ficha { get; set; }

        [ForeignKey("Denominacion")]
        public int DenominacionId { get; set; }
        public virtual Denominacion? Denominacion { get; set; }             

    }
}