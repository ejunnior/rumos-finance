namespace Finance.Api.Creditor
{
    using Application.Creditor;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Produces("application/json")]
    public class CreditorController : BaseController
    {
        private readonly IDeleteCreditorHandler _deleteHandler;
        private readonly IEditCreditorHandler _editHandler;
        private readonly IGetCreditorByIdHandler _getCreditorByIdHandler;
        private readonly IGetCreditorHandler _getCreditorHandler;
        private readonly IRegisterCreditorHandler _registerHandler;

        public CreditorController(
            IRegisterCreditorHandler registerHandler,
            IDeleteCreditorHandler deleteHandler,
            IEditCreditorHandler editHandler,
            IGetCreditorByIdHandler getCreditorByIdHandler,
            IGetCreditorHandler getCreditorHandler)
        {
            _registerHandler = registerHandler;
            _deleteHandler = deleteHandler;
            _editHandler = editHandler;
            _getCreditorByIdHandler = getCreditorByIdHandler;
            _getCreditorHandler = getCreditorHandler;
            _getCreditorByIdHandler = getCreditorByIdHandler;
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

        [HttpGet()]
        public async Task<IActionResult> GetCreditor()
        {
            var query = new GetCreditorQuery();

            var result = await _getCreditorHandler
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditorById(int id)
        {
            var query = new GetCreditorByIdQuery
            {
                Id = id
            };

            var result = await _getCreditorByIdHandler
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