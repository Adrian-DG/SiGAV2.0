using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.DTO.Pagination;
using Domain.Models.Pagination;

namespace Application.Contracts
{
    public interface IGenericRepository<T> where T : EntityMetadata
    {
        Task<PagedData<T>> GetAllAsync(PaginationFilter Filter, Expression<Func<T, bool>> Predicate, Expression<Func<T, dynamic>> OrderBy);
        Task<T> GetById(object Id);
        Task InsertAsync(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        Task<int> GetTotalRecords(Expression<Func<T, bool>> Predicate);
    }
}