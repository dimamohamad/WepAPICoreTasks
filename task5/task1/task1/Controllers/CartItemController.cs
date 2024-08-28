using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.DTOs;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {

        private readonly MyDbContext _db;

        public CartItemController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get() {
        
           var getData=_db.CartItems.Select(x=> new CartItemResponseDto {
               CartId = x.CartId,
               CartItemId = x.CartItemId,
               Quantity = x.Quantity,
               Product= new productDto {
               ProductId=x.Product.ProductId,
               Price=x.Product.Price,
               ProductName=x.Product.ProductName,
                  Description = x.Product.Description,
               
               }
           
           
           }).ToList(); 
        
        return Ok (getData);
        }



        [HttpGet("/GetDataById/{id}")]
        public IActionResult Get(int id)
        {

            var getData = _db.CartItems.Where(l => l.CartId == id).Select(x => new CartItemResponseDto
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new productDto
                {
                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,

                }


            }).ToList();

            return Ok(getData);
        }
        [HttpPost]
        public IActionResult addCartItems([FromBody] AddItemRequest cart) {
            var data = new CartItem
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,


            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }
    }
}
