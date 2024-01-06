using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Constants
{
    public static class ExceptionConstants
    {
        public const string ApplicationException = "Application exception occurred.";
        public const string KeyNotFoundException = "The request key not found.";
        public const string UnauthorizedAccessException = "Unauthorized";
        public const string DefaultException = "Internal server error. Please retry later.";
    }
}