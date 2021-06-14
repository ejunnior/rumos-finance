namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using System.Threading.Tasks;

    public class GetCategoryByIdHandler : IGetCategoryByIdHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdDto> HandleAsync(GetCategoryByIdQuery args)
        {
            var category = await _repository
                .GetAsync(args.Id);

            if (category == null)
            {
                return null;
            }

            return new GetCategoryByIdDto
            {
                Id = category.Id,
                Name = category.CategoryName
            };
        }
    }
}