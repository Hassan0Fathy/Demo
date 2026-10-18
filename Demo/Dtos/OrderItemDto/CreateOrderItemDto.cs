using Demo.Models;
using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.OrderItemDto
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
  
        public decimal UnitPrice { get; set; }

        public int ProductId { get; set; }
    }
}
