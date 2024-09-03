using task1.Models;

namespace task1.DTOs
{
    public class CartItemResponseDto
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        
        public int Quantity { get; set; }
        public  productDto Product { get; set; }
    }
    public class productDto {


        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

      
    }
}
