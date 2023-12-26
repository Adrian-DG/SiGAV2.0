using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Pagination
{
    public record PaginationFilter(int Quantity, int Page, string SearchTerm, bool Status);
}