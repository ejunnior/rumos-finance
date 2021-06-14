namespace Finance.Application.Bank
{
    using System.ComponentModel.DataAnnotations;

    public class EditBankAccountDto
    {
        [Required]
        public string AccountNumber { get; set; }
    }
}