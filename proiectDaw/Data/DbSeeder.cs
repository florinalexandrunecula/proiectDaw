using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proiectDaw.Models;

namespace proiectDaw.Data
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(ApplicationDbContext context, ILogger<DbSeeder> logger)
        {
            _context = context;
            _logger = logger;
        }

        private Project createProject(string ProjectName, bool isNull, string[] DevNames, string[] Emails, int[] HireYears, string[] Roles)
        {
            var project = new Project
            {
                ProjectName = ProjectName
            };

            if (isNull == true)
            {
                return project;
            }

            project.SoftwareDevelopers = new List<SoftwareDeveloper>();

            for (int i = 0; i < DevNames.Length; i++)
            {
                var dev = new SoftwareDeveloper
                {
                    Name = DevNames[i],
                    Email = Emails[i],
                    HireYear = HireYears[i],
                    Role = Roles[i],
                    Project = project,
                };

                var vacation = new Vacation
                {
                    AnnualLeave = 20,
                    BloodDonationLeave = 5,
                    FourHourLeave = 8,
                    SoftwareDeveloperId = dev.Id,
                    SoftwareDeveloper = dev
                };

                dev.Vacation = vacation;

                project.SoftwareDevelopers.Add(dev);
            }

            return project;
        }

        public void Seed()
        {
            var projectDb = _context.projects.Include(e => e.SoftwareDevelopers);

            Console.WriteLine("Database seeding");
            _logger.LogInformation("Database seeding");

            // Making sure the DB is clean
            _context.projects.RemoveRange(_context.projects);
            _context.softwareDevelopers.RemoveRange(_context.softwareDevelopers);
            _context.vacations.RemoveRange(_context.vacations);

            _context.SaveChanges();

            var project1 = createProject("Daw project", false, new string[] { "Necula Florin-Alexandru", "Stoian Mihai" },
                new string[] { "necula@gmail.com", "stoian@gmail.com"}, new int[] { 2020, 2019 }, new string[] { "Admin", "Dev"});
            _context.projects.Add(project1);

            var project2 = createProject("Dezvoltarea jocurilor", false, new string[] {"Sugeac Andrei", "Adi Cinca", "Albu Andreea" },
                new string[] { "sugeac@gmail.com", "cinca@gmail.com", "albu@gmail.com" }, new int[] { 2019, 2018, 2017 },
                new string[] { "Dev", "Dev", "Dev"});
            _context.projects.Add(project2);

            var project3 = createProject("No Project", true, null, null, null, null);
            project3.Id = -1;

            _context.projects.Add(project3);

            _context.SaveChanges();

            //Finished seeding message
            Console.WriteLine("Database seeded");
            _logger.LogInformation("Database seeded");


        }
    }
}
