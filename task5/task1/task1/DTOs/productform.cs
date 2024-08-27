using task1.Models;

namespace task1.DTOs
{
    public class productform
    {


       

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }


        public int? CategoryId { get; set; }

        public IFormFile? ProductImage { get; set; }

       
    }
}
