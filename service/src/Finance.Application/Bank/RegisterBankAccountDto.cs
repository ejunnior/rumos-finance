namespace Finance.Application.Bank
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterBankAccountDto
    {
        [Required]
        public string AccountNumber { get; set; }
    }
}