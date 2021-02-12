using Komar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Komar.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bite> Bites { get; set; }
        public DbSet<Bubble> Bubbles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
                Id = "1",
                Name = "Administrator",
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "129fbb1a-0cb7-436a-91a1-16cd45f7d84a",
                    UserName = "c@c",
                    Email = "c@c",
                    EmailConfirmed = true,
                    Nick = "bobot"
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "129fbb1a-0cb7-436a-91a1-16cd45f7d84a",
            });
        }
    }
}
