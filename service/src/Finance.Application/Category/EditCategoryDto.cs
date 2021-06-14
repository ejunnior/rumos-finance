namespace Finance.Application.Category
{
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}