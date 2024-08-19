using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {

        private readonly MyDbContext _db;
        public Products(MyDbContext db)
        {
            _db = db;
          
        }

        [HttpGet]
        public IActionResult Get() {
        
          var product = _db.Products.Include(p=>p.Category).ToList();
        
        return Ok(product);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {

            var product = _db.Products.Include(p => p.Category).Where(p=>p.ProductId==id).FirstOrDefault();

            return Ok(product);
        }
    }
}
