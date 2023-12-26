using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Abstraction;
using Domain.DTO.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityMetadata
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _repo;
        public GenericRepository(DbContext dbContext)
        {
            _context = dbContext;
            _repo = _context.Set<T>();
        }

        public void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync(PaginationFilter Filter, System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalRecords(System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}