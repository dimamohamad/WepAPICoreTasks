﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using task1.DTOs;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly MyDbContext _db;
        public UsersController(MyDbContext db, TokenGenerator tokenGenerator)
        {

            _db = db;
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user = _db.Users.ToList();
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("/api/Users/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _db.Users.ToList();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var x = _db.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (x != null)
            {
                return Ok(x);
            }
            return NotFound();

        }

        [Route("Users/{id}")]
        [HttpGet]
        public IActionResult GetID(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var x = _db.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (x != null)
            {
                return Ok(x);
            }
            return NotFound();

        }



        [HttpGet("name")]
        public IActionResult Getname(string name) {
            var user = _db.Users.Where(p => p.Username == name);
            if (user != null) {
                return Ok(user);
            }

            return NotFound();

        }

        [Route("username/{name}")]
        [HttpGet]
        public IActionResult GetName(string name)
        {
            var user = _db.Users.Where(p => p.Username == name).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }


            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] userform model)
        {
            byte[] passwordHash, passwordSalt;
            PasswordHasher.createPasswordHash(model.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromForm] userform model)
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == model.Username);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            var roles = _db.UserRoles.Where(x => x.UserId == user.UserId).Select(ur => ur.Role).ToList();
            var token = _tokenGenerator.GenerateToken(user.Username, roles);

            return Ok(new { Token = token });

           
        }

     
               
            [HttpGet("frequency")]
            public IActionResult GetOddFrequency(
                [FromQuery] int number1,
                [FromQuery] int number2,
                [FromQuery] int number3,
                [FromQuery] int number4,
                [FromQuery] int number5)
            {
                int[] numbers = new int[] { number1, number2, number3, number4, number5 };

                // Calculate the frequency using LINQ and filter odd frequencies
                var oddFrequency = numbers
                    .GroupBy(n => n)
                    .Select(g => new { Number = g.Key, Frequency = g.Count() })
                    .Where(x => x.Frequency % 2 != 0)
                    .ToArray();

                return Ok(oddFrequency);
            }
       



        //[HttpDelete("id")]
        //public IActionResult Delete(int id) {

        //    if (id <= 0)
        //    {
        //        return BadRequest();

        //    }

        //    var x = _db.Orders.Where(p=>p.UserId==id).ToList();

        //    _db.Orders.RemoveRange(x);
        //    _db .SaveChanges();

        //    var y= _db.Users.Where(_ => _.UserId==id).FirstOrDefault();
        //    if (y != null) { 

        //    _db.Users.Remove(y);
        //        _db .SaveChanges();
        //        return NoContent();


        //    }

        //    return NotFound();



        //}



        //[Route("/api/Users/Deleteuser/{id}")]

        //[HttpDelete]
        //public IActionResult DeleteBYId(int id)
        //{

        //    if (id <= 0)
        //    {
        //        return BadRequest();

        //    }

        //    var x = _db.Orders.Where(p => p.UserId == id).ToList();

        //    _db.Orders.RemoveRange(x);
        //    _db.SaveChanges();

        //    var y = _db.Users.Where(_ => _.UserId == id).FirstOrDefault();
        //    if (y != null)
        //    {

        //        _db.Users.Remove(y);
        //        _db.SaveChanges();
        //        return NoContent();


        //    }

        //    return NotFound();



        //}



        //[HttpPost]
        //public IActionResult postuser([FromForm] userform user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();

        //    }
        //    var x = new User
        //    {

        //        Username = user.Username,
        //        Password = user.Password,


        //    };



        //    _db.Users.Add(x);
        //    _db.SaveChanges();
        //    return Ok(x);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UPDATE([FromForm] userform user, int id)
        //{



        //    var c = _db.Users.FirstOrDefault(l => l.UserId == id);
        //    c.Username = user.Username;

        //    c.Password = user.Password;

        //    _db.Users.Update(c);
        //    _db.SaveChanges();




        //    return Ok();

        //    //ضيفي كود الصورة 

        //}
    }
}
