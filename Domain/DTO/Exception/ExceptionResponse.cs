using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Domain.DTO.Exception
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}