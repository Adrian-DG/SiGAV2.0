using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Usuario
{
	public record UserChangePasswordDTO(string username, string newPassword);
}
