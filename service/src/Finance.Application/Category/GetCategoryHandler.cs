namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetCategoryHandler : IGetCategoryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetCategoryDto>> HandleAsync(GetCategoryQuery args)
        {
            var categories = _repository
                .GetAll();

            if (categories == null)
            {
                return null;
            }

            return categories.Select(
                category => new GetCategoryDto
                {
                    Id = category.Id,
                    Name = category.CategoryName.Value
                }).ToList();
        }
    }
}