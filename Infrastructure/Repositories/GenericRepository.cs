using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Abstraction;
using Domain.DTO.Pagination;
using Domain.Models.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            Entity.ChangeVisibility();
            _context.Attach<T>(Entity);
            _context.Entry<T>(Entity).State = EntityState.Modified;
        }

        public async Task<PagedData<T>> GetAllAsync(PaginationFilter Filter, Expression<Func<T, bool>> Predicate, Expression<Func<T, dynamic>> OrderBy)
        {
            var result = await _repo
                        .Where(Predicate)
                        .Skip<T>((Filter.Page - 1) * Filter.Size)
                        .Take<T>(Filter.Size)
                        .OrderBy(OrderBy)
                        .ThenBy(o => o.FechaCreacion)
                        .ToListAsync<T>();

            int total = await GetTotalRecords(Predicate);

            return new PagedData<T>(Filter.Page, Filter.Size,result, total);
        }

        public async Task<T> GetById(object Id) => await _repo.FindAsync(Id);

        public async Task<int> GetTotalRecords(System.Linq.Expressions.Expression<Func<T, bool>> Predicate) => await _repo.CountAsync(Predicate);

        public async Task InsertAsync(T Entity) => await _repo.AddAsync(Entity);

        public void Update(T Entity)
        {
            _context.Attach<T>(Entity);
            _context.Entry<T>(Entity).State = EntityState.Modified;
        }
    }
}