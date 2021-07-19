namespace Finance.Api.Category
{
    using System.Threading.Tasks;
    using Application.Bank;
    using Application.Category;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    //[Authorize]
    public class CategoryController : BaseController
    {
        private readonly IDeleteCategoryHandler _deleteHandler;
        private readonly IEditCategoryHandler _editHandler;
        private readonly IGetCategoryByIdHandler _queryHandler;
        private readonly IRegisterCategoryHandler _registerHandler;

        public CategoryController(
            IRegisterCategoryHandler registerHandler,
            IDeleteCategoryHandler deleteHandler,
            IEditCategoryHandler editHandler,
            IGetCategoryByIdHandler queryHandler)
        {
            _registerHandler = registerHandler;
            _deleteHandler = deleteHandler;
            _editHandler = editHandler;
            _queryHandler = queryHandler;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteCategoryCommand(id);

            await _deleteHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCategoryDto dto)
        {
            var command = new EditCategoryCommand(
                id: id,
                categoryName: dto.CategoryName);

            await _editHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id
            };

            var result = await _queryHandler
                .HandleAsync(query);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command =
                new RegisterCategoryCommand(dto.CategoryName);

            await _registerHandler
                .HandleAsync(command);

            return Ok();
        }
    }
}