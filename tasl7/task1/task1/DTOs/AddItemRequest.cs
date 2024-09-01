using task1.Models;

namespace task1.DTOs
{
    public class AddItemRequest
    {

        

        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

       
    }
}
