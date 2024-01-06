using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Departamento;

namespace Domain.Entities.Usuario
{
    public class Usuario : IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento.Departamento? Departamento { get; set; }
        public bool IsActive { get; set; }
        public string UserInformation() =>  $"{Nombre} {Apellido}";
    }
}