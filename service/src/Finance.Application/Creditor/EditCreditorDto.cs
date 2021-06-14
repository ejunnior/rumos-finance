namespace Finance.Application.Creditor
{
    using System.ComponentModel.DataAnnotations;

    public class EditCreditorDto
    {
        [Required]
        public string CreditorName { get; set; }
    }
}