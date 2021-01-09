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
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(ApplicationDbContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/getUserRole")]
        public IEnumerable<bool> GetUserRole()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Where(usr => usr.Id == userId).First();
            var auth = false;

            var role = _context.softwareDevelopers.Where(dev => dev.Email == user.Email).First().Role;
            if (role == "Admin") {
                auth = true;
            }

            List<bool> authlist = new List<bool>();
            authlist.Add(auth);
            return authlist;
        }
    }
}