using Domain.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Pagination
{
	public record PagedData<T>(int Page, int Size, List<T> Items, int TotalCount) where T : EntityMetadata;
}
