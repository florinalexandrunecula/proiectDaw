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
using Microsoft.EntityFrameworkCore;

namespace proiectDaw.Controllers
{
    [Authorize]
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
                var role = json["role"].ToString();

                Console.WriteLine(name);
                Console.WriteLine(email);

                var dev = new SoftwareDeveloper();
                dev.Name = name;
                dev.Email = email;
                dev.HireYear = DateTime.Now.Year;
                dev.Role = role;
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

        [HttpPost("/softwareDeveloper/delete")]
        public Boolean Delete()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var name = json["name"].ToString();
                var email = json["email"].ToString();

                var dev = (_context.softwareDevelopers.Where(dev => dev.Name == name && dev.Email == email)).First();

                var project = (_context.projects.Include(e => e.SoftwareDevelopers).Where(prj => prj.Id == dev.ProjectId)).First();
                project.SoftwareDevelopers.Remove(dev);

                var vacation = (_context.vacations.Where(vac => vac.SoftwareDeveloperId == dev.Id)).First();
                _context.vacations.Remove(vacation);

                _context.softwareDevelopers.Remove(dev);

                _context.SaveChanges();
                return true;
            }

            return true;



        }

        [HttpPost("/softwareDeveloper/update")]
        public Boolean Update()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var oldname = json["oldname"].ToString();
                var oldemail = json["oldemail"].ToString();
                var oldrole = json["oldrole"].ToString();
                var oldproject = json["oldproject"].ToString();

                var newname = json["newname"].ToString();
                var newemail = json["newemail"].ToString();
                var newrole = json["newrole"].ToString();
                var newproject = json["newproject"].ToString();

                var dev = (_context.softwareDevelopers.Where(dev => dev.Name == oldname && dev.Email == oldemail)).First();

                var oldprojectob = (_context.projects.Include(e => e.SoftwareDevelopers).Where(prj => prj.Id == dev.ProjectId)).First();
                oldprojectob.SoftwareDevelopers.Remove(dev);

                var newprojectob = (_context.projects.Include(e => e.SoftwareDevelopers).Where(prj => prj.ProjectName == newproject)).First();

                dev.Name = newname;
                dev.Email = newemail;
                dev.Role = newrole;
                dev.Project = newprojectob;

                newprojectob.SoftwareDevelopers.Add(dev);

                _context.SaveChanges();
                return true;
            }

            return true;
        }

        [HttpPost("/softwareDeveloper/vacation")]
        public Boolean Vacation()
        {
            Console.WriteLine("Package received...");

            var received = Request.Form.Keys;

            foreach (var key in received)
            {
                var json = JObject.Parse(key);

                var oldname = json["oldname"].ToString();
                var oldemail = json["oldemail"].ToString();
                var oldrole = json["oldrole"].ToString();
                var oldproject = json["oldproject"].ToString();

                var newname = json["newname"].ToString();
                var newemail = json["newemail"].ToString();
                var newrole = json["newrole"].ToString();
                var newproject = json["newproject"].ToString();

                var dev = (_context.softwareDevelopers.Where(dev => dev.Name == oldname && dev.Email == oldemail)).First();

                var oldprojectob = (_context.projects.Include(e => e.SoftwareDevelopers).Where(prj => prj.Id == dev.ProjectId)).First();
                oldprojectob.SoftwareDevelopers.Remove(dev);

                var newprojectob = (_context.projects.Include(e => e.SoftwareDevelopers).Where(prj => prj.ProjectName == newproject)).First();

                dev.Name = newname;
                dev.Email = newemail;
                dev.Role = newrole;
                dev.Project = newprojectob;

                newprojectob.SoftwareDevelopers.Add(dev);

                _context.SaveChanges();
                return true;
            }

            return true;
        }
    }
}
