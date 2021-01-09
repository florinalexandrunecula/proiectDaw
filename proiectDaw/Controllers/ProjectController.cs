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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ApplicationDbContext context, ILogger<ProjectController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/projects")]
        public IEnumerable<Project> Get()
        {
            return _context.projects.ToList();
        }

        [HttpPost("/projects/create")]
        public Boolean Create()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var name = json["name"].ToString();

                Console.WriteLine(name);

                var prj = new Project();
                prj.ProjectName = name;

                prj.SoftwareDevelopers = null;

                _context.projects.Add(prj);
                _context.SaveChanges();
                return true;
            }

            return true;
        }

    }
}
