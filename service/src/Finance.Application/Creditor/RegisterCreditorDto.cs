namespace Finance.Application.Creditor
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterCreditorDto
    {
        [Required]
        public string CreditorName { get; set; }
    }
}