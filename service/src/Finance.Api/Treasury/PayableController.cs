namespace Finance.Api.Treasury
{
    using Application.Treasury;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Produces("application/json")]
    public class PayableController : BaseController
    {
        private readonly IDeletePayableAccountHandler _deleteHandler;
        private readonly IEditPayableAccountHandler _editHandler;
        private readonly IGetPayableAccountByIdHandler _payableAccountByIdHandler;
        private readonly IGetPayableAccountHandler _payableAccountHandler;
        private readonly IRegisterPayableAccountHandler _registerHandler;

        public PayableController(
            IRegisterPayableAccountHandler registerHandler,
            IEditPayableAccountHandler editHandler,
            IDeletePayableAccountHandler deleteHandler,
            IGetPayableAccountByIdHandler payableAccountByIdHandler,
            IGetPayableAccountHandler payableAccountHandler)
        {
            _registerHandler = registerHandler;
            _editHandler = editHandler;
            _deleteHandler = deleteHandler;
            _payableAccountByIdHandler = payableAccountByIdHandler;
            _payableAccountHandler = payableAccountHandler;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeletePayableAccountCommand(id);

            await _deleteHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditPayableAccountDto dto)
        {
            var command = new EditPayableAccountCommand(
                paymentDate: dto.PaymentDate,
                dueDate: dto.DueDate,
                documentDate: dto.DocumentDate,
                documentNumber: dto.DocumentNumber,
                description: dto.Description,
                creditorId: dto.CreditorId,
                categoryId: dto.CategoryId,
                bankAccountId: dto.BankAccountId,
                amount: dto.Amount,
                id: id);

            await _editHandler
                .HandleAsync(command);

            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetPayableAccount()
        {
            var query = new GetPayableAccountQuery();

            var result = await _payableAccountHandler
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
        public async Task<IActionResult> GetPayableAccountById(int id)
        {
            var query = new GetPayableAccountByIdQuery
            {
                Id = id
            };

            var result = await _payableAccountByIdHandler
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

        // Post
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Register([FromBody] RegisterPayableAccountDto dto)
        {
            var command = new RegisterPayableAccountCommand(
                paymentDate: dto.PaymentDate,
                dueDate: dto.DueDate,
                documentDate: dto.DocumentDate,
                documentNumber: dto.DocumentNumber,
                description: dto.Description,
                creditorId: dto.CreditorId,
                categoryId: dto.CategoryId,
                bankAccountId: dto.BankAccountId,
                amount: dto.Amount);

            await _registerHandler
                .HandleAsync(command);

            return Ok();
        }
    }
}