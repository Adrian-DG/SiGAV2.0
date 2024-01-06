using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts
{
    public interface IUnitOfWork
    {
        DbContext GetDbContext();
        Task CommitChangesAsync();
        IGenericRepository<T> Repository<T>() where T : EntityMetadata;
    }
}