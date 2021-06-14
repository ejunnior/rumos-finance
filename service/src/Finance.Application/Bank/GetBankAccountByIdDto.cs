namespace Finance.Application.Bank
{
    using Domain.Core;

    public class GetBankAccountByIdDto
    {
        public string AccountNumber { get; set; }
        public int Id { get; set; }
    }
}