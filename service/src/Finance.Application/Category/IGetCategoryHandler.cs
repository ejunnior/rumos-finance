namespace Finance.Application.Category
{
    using System.Collections.Generic;
    using Domain.Core;

    public interface IGetCategoryHandler : IQueryHandler<GetCategoryQuery, IList<GetCategoryDto>>
    {
    }
}