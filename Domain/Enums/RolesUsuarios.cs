using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
	public enum RolesUsuarios 
	{
		[Description("Acceso a todo el sistema")]
		ADMINISTRADOR = 1,

		[Description("Acciones necesarias para analista.")]
		ANALISTA_S3,

		[Description("Acciones limitadas solo a la creacion y actualizacion de las asistencias.")]
		OPERADOR_R5
	}
}
