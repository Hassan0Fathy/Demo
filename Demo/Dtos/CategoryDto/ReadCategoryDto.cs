using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.CategoryDto
{
    public class ReadCategoryDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
