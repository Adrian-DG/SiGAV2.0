using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Application.Contracts
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
        IGenericRepository<T> Repository<T>() where T : EntityMetadata;
    }
}