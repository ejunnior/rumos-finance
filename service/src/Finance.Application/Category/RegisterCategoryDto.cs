namespace Finance.Application.Category
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}