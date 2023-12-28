using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Aurthenticated
{
    public record AuthenticatedResponse
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}