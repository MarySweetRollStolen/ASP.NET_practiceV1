using asp_pract.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_pract.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "9245fe4a-d402-451c-b9ed-9c1a04247482",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "9245fe4a-d402-451c-b9ed-9c1a04247481",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "ny@mail.com",
                NormalizedEmail = "MY@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole <string>> ().HasData(new IdentityUserRole<string>
            {
                RoleId = "9245fe4a-d402-451c-b9ed-9c1a04247482",
                UserId = "9245fe4a-d402-451c-b9ed-9c1a04247481"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247258"),
                CodeWord = "PageIndex",
                Title = "Головна"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247369"),
                CodeWord = "PageServices",
                Title = "Послуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247547"),
                CodeWord = "PageContacts",
                Title = "Контакти"
            });
        }

    }
}
