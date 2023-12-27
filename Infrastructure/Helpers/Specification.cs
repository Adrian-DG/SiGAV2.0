using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Helpers;
using Domain.Abstraction;

namespace Infrastructure.Helpers
{
    public class Specification<T> : ISpecification<T> where T : EntityMetadata
    {
        public Expression<Func<T, bool>> GetPredicate(Expression<Func<T, bool>> expression) => expression;
    }
}