using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.CategoryDto
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
