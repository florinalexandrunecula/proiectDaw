﻿using proiectDaw.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDaw.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SoftwareDeveloper>()
                .HasOne(p => p.Project)
                .WithMany(b => b.SoftwareDevelopers)
                .HasForeignKey(p => p.ProjectId);
            builder.Entity<SoftwareDeveloper>()
                .HasOne(p => p.Vacation)
                .WithOne(b => b.SoftwareDeveloper)
                .HasForeignKey<Vacation>(k => k.SoftwareDeveloperId);
        }

        public DbSet<SoftwareDeveloper> softwareDevelopers { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Vacation> vacations { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Review> reviews { get; set; }
    }

}
