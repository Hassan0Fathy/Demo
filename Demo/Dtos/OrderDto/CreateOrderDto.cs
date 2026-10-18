using Demo.Dtos.OrderItemDto;
using Demo.Models;
using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.OrderDto
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }


        public string Status { get; set; }

        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }

        public ICollection<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
    }
}
