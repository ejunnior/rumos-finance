namespace Finance.Api.Creditor
{
    using Application.Creditor;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Produces("application/json")]
    [Authorize]
    public class CreditorController : BaseController
    {
        private readonly IDeleteCreditorHandler _deleteHandler;
        private readonly IEditCreditorHandler _editHandler;
        private readonly IGetCreditorByIdHandler _queryHandler;
        private readonly IRegisterCreditorHandler _registerHandler;

        public CreditorController(
            IRegisterCreditorHandler registerHandler,
            IDeleteCreditorHandler deleteHandler,
            IEditCreditorHandler editHandler,
            IGetCreditorByIdHandler queryHandler)
        {
            _registerHandler = registerHandler;
            _deleteHandler = deleteHandler;
            _editHandler = editHandler;
            _queryHandler = queryHandler;
            _registerHandler = registerHandler;
            _deleteHandler = deleteHandler;
            _editHandler = editHandler;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteCreditorCommand(id);

            await _deleteHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id,
            [FromBody] EditCreditorDto dto)
        {
            var command = new EditCreditorCommand(
                id: id,
                creditorName: dto.CreditorName);

            await _editHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditorById(int id)
        {
            var query = new GetCreditorByIdQuery
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
            [FromBody] RegisterCreditorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command =
                new RegisterCreditorCommand(dto.CreditorName);

            await _registerHandler
                .HandleAsync(command);

            return Ok();
        }
    }
}