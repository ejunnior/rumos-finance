namespace Finance.Api.Treasury
{
    using System.Diagnostics.SymbolStore;
    using System.Threading.Tasks;
    using Application.Treasury;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Microsoft.AspNetCore.Mvc;

    public class PayableController : BaseController
    {
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

            var handler = new RegisterPayableAccountHandler();

            await handler
                .HandlerAsync(command);

            return Ok();
        }
    }
}