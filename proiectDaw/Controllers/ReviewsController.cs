using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proiectDaw.Data;
using proiectDaw.Models;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace proiectDaw.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(ApplicationDbContext context, ILogger<ReviewsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/reviews")]
        public IEnumerable<Review> Get()
        {
            return _context.reviews.ToList();
        }

        [HttpPost("/reviews/create")]
        public Boolean Create()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var owner = json["owner"].ToString();
                var description = json["description"].ToString();
                var rating = json["rating"];

                var rev = new Review();
                rev.owner = owner;
                rev.description = description;
                rev.rating = (int)rating;

                _context.reviews.Add(rev);
                _context.SaveChanges();
                return true;
            }

            return true;
        }
    }
}
