using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeVsVirus.DataAccess.Specifications;
using WeVsVirus.Models;

namespace WeVsVirus.DataAccess
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        internal static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query;
        }

        internal async static Task<IEnumerable<IGrouping<TK, T>>> GetGroupingEnumerableAsync<TK>(IQueryable<T> inputQuery, IGroupingSpecification<T, TK> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            var query = GetQuery(inputQuery, specification);

            if (specification.GroupBy != null)
            {
                return (await query.ToListAsync()).GroupBy(specification.GroupBy.Compile());
            }
            throw new Exception("GroupBy Expression was missing.");
        }
    }
}
