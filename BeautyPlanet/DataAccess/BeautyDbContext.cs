using BeautyPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.DataAccess
{
    public class BeautyDbContext:IdentityDbContext<IdentityUser>
    {
       public  BeautyDbContext(DbContextOptions<BeautyDbContext> options):base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Platform> Platforms { get; set; } 
    }
}
