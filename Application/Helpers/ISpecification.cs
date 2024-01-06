using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Application.Helpers
{
    public interface ISpecification<T> where T : EntityMetadata
    {
        Expression<Func<T, bool>> GetPredicate(Expression<Func<T, bool>> expression);
        Expression<Func<T, dynamic>> GetOrderBy(Expression<Func<T, dynamic>> selector);
    }
}