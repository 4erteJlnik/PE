using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web1.Domain;

namespace Web1.Infrastructure
{
    public class WebContext : IdentityDbContext<Peoplelogin, IdentityRole<Guid>, Guid>
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //    optionsBuilder.UseSqlite("Data Source=../Infrastructure/DB");
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Entity<IdentityUser>();
            modelBuilder.ApplyConfiguration(new PostCommentConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleloginConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public WebContext(DbContextOptions opt) : base(opt)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
