namespace Finance.Api.Bank
{
    using Application.Bank;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Produces("application/json")]
    public class BankAccountController : BaseController
    {
        private readonly IGetBankAccountHandler _bankAccountQueryHanlder;
        private readonly IDeleteBankAccountHandler _deleteHandler;
        private readonly IEditBankAccountHandler _editHandler;
        private readonly IGetBankAccountByIdHandler _queryHandler;
        private readonly IRegisterBankAccountHandler _registerHandler;

        public BankAccountController(
            IRegisterBankAccountHandler registerHandler,
            IDeleteBankAccountHandler deleteHandler,
            IEditBankAccountHandler editHandler,
            IGetBankAccountByIdHandler queryHandler,
            IGetBankAccountHandler bankAccountQueryHanlder)
        {
            _registerHandler = registerHandler;
            _deleteHandler = deleteHandler;
            _editHandler = editHandler;
            _queryHandler = queryHandler;
            _bankAccountQueryHanlder = bankAccountQueryHanlder;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteBankAccountCommand(id);

            await _deleteHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditBankAccountDto dto)
        {
            var command = new EditBankAccountCommand(
                id: id,
                accountNumber: dto.AccountNumber);

            await _editHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetBankAccount()
        {
            var query = new GetBankAccountQuery();

            var result = await _bankAccountQueryHanlder
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
        public async Task<IActionResult> GetBankAccountById(int id)
        {
            var query = new GetBankAccountByIdQuery
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
            [FromBody] RegisterBankAccountDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command =
                new RegisterBankAccountCommand(dto.AccountNumber);

            await _registerHandler
                .HandleAsync(command);

            return Ok();
        }
    }
}