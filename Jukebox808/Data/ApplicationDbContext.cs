﻿using System;
using System.Collections.Generic;
using System.Text;
using Jukebox808.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mowerman.Models;

namespace Mowerman.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public DbSet<TimeClock> TimeClock { get; set; }
        public object Customer { get; internal set; }

    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Customer",
                        NormalizedName = "Customer"
                    },
                    new IdentityRole
                    {
                        Name = "Employee",
                        NormalizedName = "Employee"
                    },
                    new IdentityRole
                    {
                        Name = "Operation",
                        NormalizedName = "Operation"
                    });
        }
    }
}
