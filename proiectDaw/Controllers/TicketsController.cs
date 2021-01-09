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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ApplicationDbContext context, ILogger<TicketController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/tickets")]
        public IEnumerable<Ticket> Get()
        {
            return _context.tickets.ToList();
        }

        [HttpPost("/tickets/create")]
        public Boolean Create()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var title = json["title"].ToString();
                var description = json["description"].ToString();

                var tick = new Ticket();
                tick.title = title;
                tick.description = description;

                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = _context.Users.Where(usr => usr.Id == userId).First();

                tick.owner = user.Email;

                _context.tickets.Add(tick);
                _context.SaveChanges();
                return true;
            }

            return true;
        }
    }
}
