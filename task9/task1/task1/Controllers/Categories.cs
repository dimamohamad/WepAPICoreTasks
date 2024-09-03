using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.DTOs;

using task1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
       
        public IActionResult Get()
        {

            var categories = _db.Categories.ToList();
            return Ok(categories);
        }


        [Route("api/categories/getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var categories = _db.Categories.Where(p => p.CategoryId == id).FirstOrDefault();

        //    return Ok(categories);
        //}



        [HttpGet("{id:min(5)}")]
        public IActionResult Get(int id)
        {
            var categories = _db.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }


        [HttpGet]
        [Route("/api/categories/categryId/{id1:int:min(5)}")]
        public IActionResult GetById(int id1)
        {

            var x = _db.Categories.Where(p => p.CategoryId == id1).FirstOrDefault();
            if (x == null)
                return BadRequest();
            return Ok(x);



        }




        [HttpGet("name")]
        public IActionResult GetName(string name)
        {
            var categories = _db.Categories.Where(p => p.CategoryName == name).FirstOrDefault();
            if (categories != null)
            {

                return Ok($"the category name is  {name}");

            }
            return NotFound();
        }

        [Route("/api/Categories/CategoryName/{name}")]
        [HttpGet]
        public IActionResult Getname(string name)
        {
            var categories = _db.Categories.Where(p => p.CategoryName == name).FirstOrDefault();
            if (categories != null)
            {

                return Ok($"the category name is  {name}");

            }
            return NotFound();
        }


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var category = _db.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);
        //    if (category != null)
        //    {

        //        _db.Products.RemoveRange(category.Products);


        //        _db.Categories.Remove(category);
        //        _db.SaveChanges();
        //        return NoContent();
        //    }
        //    return NotFound();
        //}
      


        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var deleteproduct = _db.Products.Where(l => l.CategoryId == id).ToList();


            _db.Products.RemoveRange(deleteproduct);
            _db.SaveChanges();



            var deleteCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (deleteCategory != null)
            {
                _db.Categories.Remove(deleteCategory);
                _db.SaveChanges();
                return NoContent();

            }
            return NotFound();
        }


        [Route("/api/categories/deletecategory/{id}")]
        [HttpDelete]
        public IActionResult delete(int id) {
          

            if (id <= 0) {  return BadRequest(); }


            var x=_db.Products.Where(p=> p.CategoryId == id).ToList();
        
                _db.Products.RemoveRange(x);
            _db.SaveChanges();


            var xdelete = _db.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (xdelete != null) {
                _db.Categories.Remove(xdelete);
                _db.SaveChanges();
                return NoContent();
            }

          return NotFound();


           
        }


        [HttpPost]
        public IActionResult postcat([FromForm] categoryform cat) {
            if (!ModelState.IsValid) {
            return BadRequest();
            
            }
            var x = new Category
            {
                CategoryImage = cat.CategoryImage.FileName,
                CategoryName = cat.CategoryName,


            };
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, cat.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                cat.CategoryImage.CopyToAsync(stream);
            }


            _db.Categories.Add(x);
            _db.SaveChanges();
            return Ok(x);
        }

        [HttpPut("{id}")]
        public IActionResult UPDATE([FromForm] categoryform categDto, int id)
        {



            var c = _db.Categories.FirstOrDefault(l => l.CategoryId == id);
            c.CategoryName = categDto.CategoryName;
            c.CategoryImage = categDto.CategoryImage.FileName;

            _db.Categories.Update(c);
            _db.SaveChanges();



            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, categDto.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                categDto.CategoryImage.CopyToAsync(stream);
            }

            return Ok();

            //ضيفي كود الصورة 

        }

        //[HttpGet("{x}/{y}")]
        //public IActionResult det(int x, int y)
        //{
        //    if (x+y==30||x==30||y==30)
        //        return Ok(true);
        //    return Ok(false);
        //}
        //[HttpGet ("API/{z}")]
        //public IActionResult che(int z)
        //{ if (z > 0) { 
        //    if (z % 7 == 0 || z % 3 == 0)
        //        {
        //           return Ok(true);
        //        }
           
            
        //    }
        //    return Ok(false);
        //}
    }
}
