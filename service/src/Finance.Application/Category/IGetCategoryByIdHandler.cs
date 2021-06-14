namespace Finance.Application.Category
{
    using Domain.Core;

    public interface IGetCategoryByIdHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
    {
    }
}