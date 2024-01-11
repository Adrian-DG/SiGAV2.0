using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Usuario
{
    public record UserRegisterDTO(string nombre, string apellido, string username, string password, int departmentoId);
    
}