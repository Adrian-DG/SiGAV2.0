using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Abstraction;
using Infrastructure.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public async Task CommitChangesAsync() => await _context.SaveChangesAsync(); 

        public IGenericRepository<T> Repository<T>() where T : EntityMetadata
        {
            return new GenericRepository<T>(_context);
        }
    }
}