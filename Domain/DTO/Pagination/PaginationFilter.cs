using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Pagination
{

    public record PaginationFilter(int Page, int Size, string SearchTerm = "", bool Status = true);
}