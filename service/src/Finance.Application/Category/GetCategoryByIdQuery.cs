namespace Finance.Application.Category
{
    using Domain.Core;

    public class GetCategoryByIdQuery : IQuery<GetCategoryByIdDto>
    {
        public int Id { get; set; }
    }
}