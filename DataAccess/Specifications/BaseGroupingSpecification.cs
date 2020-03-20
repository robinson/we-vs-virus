using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WeVsVirus.DataAccess.Specifications
{
    public abstract class BaseGroupingSpecification<T, TK> : BaseSpecification<T>, IGroupingSpecification<T, TK>
    {
        public BaseGroupingSpecification(Expression<Func<T, bool>> criteria, Expression<Func<T, TK>> groupBy) : base(criteria)
        {
            GroupBy = groupBy;
        }
        public Expression<Func<T, TK>> GroupBy { get; private set; }
    }
}