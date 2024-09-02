using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.DTOs;
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
        public IActionResult Get()
        {

            var product = _db.Products.ToList();

            return Ok(product);
        }



        [HttpGet("/api/last")]
        public IActionResult order()
        {

            var order = _db.Products.OrderBy(i => i.ProductName).ToList().TakeLast(5);
            if (order != null)
            {

                return Ok(order);


            }


            return NotFound();

        }





        [HttpGet("/api/last/1")]
        public IActionResult orderx()
        {

            var order = _db.Products.OrderByDescending(i => i.ProductName).ToList().Take(5).Reverse();
            if (order != null)
            {

                return Ok(order);


            }


            return NotFound();

        }
        [Route("/api/Products/GetAll")]
        [HttpGet]
        public IActionResult GetALL()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {

            var product = _db.Products.Where(p => p.ProductId == id).FirstOrDefault();

            return Ok(product);
        }


        [HttpGet("Products/productsbycategoryid/{id}")]
        public IActionResult GetbyId(int id)
        {
            if (id >= 0)
            {
                var product = _db.Products.Where(p => p.CategoryId == id).ToList();

                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet("{id:int:min(5)}")]
        public IActionResult GetById(int id)
        {
            if (id >= 0)
            {
                var product = _db.Products.Where(p => p.ProductId == id).FirstOrDefault();

                return Ok(product);
            }
            return BadRequest();
        }

        [Route("/api/Products/Id/{id:int:min(5)}")]
        [HttpGet]
        public IActionResult GetByid(int id)
        {
            if (id >= 0)
            {
                var product = _db.Products.Where(p => p.ProductId == id).FirstOrDefault();

                return Ok(product);
            }
            return BadRequest();
        }




        [HttpDelete("id1")]
        public IActionResult Delete(int id1)
        {

            var product = _db.Products.Find(id1);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [Route("/api/Products/DeleteProduct/{id}")]
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("name")]
        public IActionResult Name(string name)
        {
            var products = _db.Products.Where(p => p.ProductName == name);
            return Ok(products);
        }

        [HttpGet("{id:int:max(10)}/{name}")]
        public IActionResult Name(int id, string name)
        {

            var products = _db.Products.Where(p => p.ProductName == name && p.ProductId == id).FirstOrDefault();
            if (products != null)
                return Ok($"the product of the {id} is {name}");

            return NotFound();
        }



        [Route("Products/productsName/{name}/productid/{id:int:max(10)}")]
        [HttpGet]
        public IActionResult details(string name, int id)
        {

            var x = _db.Products.Where(p => p.ProductName == name && p.ProductId == id).FirstOrDefault();
            if (x != null)
                return Ok($"the id of the products id {id} name is : {name}");

            return NotFound();
        }



        [Route("Products/{id}")]
        [HttpGet]
        public IActionResult Id(int id)
        {

            var p = _db.Products.Find(id);
            if (p != null)
                return Ok($"the products of this id is  {id}");
            return NotFound();
        }



        [HttpGet("/price")]
        public IActionResult Price()
        {
            var products = _db.Products.OrderByDescending(p => p.Price).ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post([FromForm] productform po) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var x = new Product
            {
                ProductName = po.ProductName,
                Price = po.Price,
                ProductImage = po.ProductImage.FileName,
                Description = po.Description,
                CategoryId=po.CategoryId,
            };
            _db.Products.Add(x);
            _db.SaveChanges();

            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, po.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                po.ProductImage.CopyToAsync(stream);
            }
            return Ok();

        
        }


        [HttpPut("{id}")]
        public IActionResult UPDATE([FromForm] productform productco, int id)
        {



            var c = _db.Products.FirstOrDefault(l => l.ProductId == id);
            c.ProductName = productco.ProductName;
            c.ProductImage = productco.ProductImage.FileName;
            c.Description = productco.Description; 
            c.CategoryId = productco.CategoryId;
            c.Price = productco.Price;
            _db.Products.Update(c);
            _db.SaveChanges();



            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, productco.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                productco.ProductImage.CopyToAsync(stream);
            }

            return Ok();

            //ضيفي كود الصورة 

        }


        //[HttpGet]
        //public IActionResult Get()
        //{

        //    var product = _db.Products.Include(p => p.Category).ToList();

        //    return Ok(product);
        //}





        //[HttpGet("id")]
        //public IActionResult Get(int id)
        //{

        //    var product = _db.Products.Include(p => p.Category).Where(p => p.ProductId == id).FirstOrDefault();

        //    return Ok(product);
        //}






        //[HttpGet("idd")]
        //public IActionResult Get(int idd ,decimal x)
        //{
        //    // var x  =  

        //    var product = _db.Products.Where(p => p.CategoryId == idd && (Convert.ToDecimal(p.Price) > x)).Count();

        //    return Ok(product);
        //}

    }
}
