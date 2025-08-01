using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FoodRescue.Domain.Abstractions;

namespace FoodRescue.Domain.Specifications;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TModel> Build<TModel>(IQueryable<TModel> queryable, Specification<TModel> specification)
    where TModel : BaseModel
    {
        if(specification.Criteria is not null)
            queryable = queryable.Where(specification.Criteria);

        if(specification.Includes is not null)
            foreach(Expression<Func<TModel, object>> include in specification.Includes)
                queryable = queryable.Include(include);

        if(specification.OrderBy is not null)
            queryable = queryable.OrderBy(specification.OrderBy);

        return queryable;
    }

    public static IQueryable<TResult> Build<TModel, TResult>(IQueryable<TModel> queryable, Specification<TModel, TResult> specification)
    where TModel : BaseModel =>
        Build<TModel>(queryable, specification).Select(specification.Selector!);
}
