using BeautyPlanet.Models;
using BeautyPlanet.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.DataAccess
{
    public class BeautyDbContext : IdentityDbContext<Person>
    {
        public BeautyDbContext(DbContextOptions<BeautyDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Person> Persons{get;set;}
        public DbSet<Specialist> Specialists { get; set; }
        
    }
}
