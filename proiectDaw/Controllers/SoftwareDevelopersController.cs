using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proiectDaw.Data;
using proiectDaw.Models;

namespace proiectDaw.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SoftwareDevelopersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SoftwareDevelopersController> _logger;

        public SoftwareDevelopersController(ApplicationDbContext context, ILogger<SoftwareDevelopersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/softwareDevelopers")]
        public IEnumerable<SoftwareDeveloper> Get()
        { 
            return _context.softwareDevelopers.ToList();
        }
    }
}
