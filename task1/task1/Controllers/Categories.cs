using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly MyDbContext _db;

        public Categories(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get() {

            var categories = _db.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("id")]
        public IActionResult Get(int id) {
            var categories = _db.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
        
        return Ok(categories);
        }
    }
}
