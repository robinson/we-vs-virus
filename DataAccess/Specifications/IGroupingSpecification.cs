using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeVsVirus.DataAccess.Specifications
{
    public interface IGroupingSpecification<T, TK> : ISpecification<T>
    {
        Expression<Func<T, TK>> GroupBy { get; }
    }
}
