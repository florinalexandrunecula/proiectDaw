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

        [HttpPost("/softwareDeveloper/create")]
        public Boolean Create()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var name = json["name"].ToString();
                var email = json["email"].ToString();

                Console.WriteLine(name);
                Console.WriteLine(email);

                var dev = new SoftwareDeveloper();
                dev.Name = name;
                dev.Email = email;
                dev.HireYear = DateTime.Now.Year;
                Console.WriteLine(dev.HireYear.GetType());

                dev.ProjectId = -1;
                var emptyProject = (_context.projects.Where(prj => prj.Id == -1)).First();

                dev.Project = emptyProject;

                var vacation = new Vacation
                {
                    AnnualLeave = 20,
                    BloodDonationLeave = 5,
                    FourHourLeave = 8,
                };

                dev.Vacation = vacation;
                _context.softwareDevelopers.Add(dev);
                _context.SaveChanges();
                return true;
            }

            return true;
            


        }
    }
}
