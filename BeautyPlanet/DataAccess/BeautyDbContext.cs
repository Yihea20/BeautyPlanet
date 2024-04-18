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
            modelBuilder.Entity<Service>().HasMany(c => c.Centers).WithMany(s => s.Services).UsingEntity<ServiceCenter>
                (sc => sc.HasOne(prop => prop.Center).WithMany().HasForeignKey(prop => prop.CenterId),
                sc => sc.HasOne(prop => prop.Service).WithMany().HasForeignKey(prop => prop.ServiceId),
                sc => sc.HasIndex(prop => new { prop.ServiceId, prop.CenterId }));
            modelBuilder.Entity<Service>().HasMany(sp => sp.Specialists).WithMany(s => s.Services).UsingEntity<ServiceSpecialist>
                (ss => ss.HasOne(prop => prop.Specialistt).WithMany().HasForeignKey(prop => prop.SpecialistId),
                ss => ss.HasOne(prop => prop.Servicee).WithMany().HasForeignKey(prop => prop.ServiceId),
                ss => ss.HasIndex(prop => new { prop.ServiceId, prop.SpecialistId }));
            modelBuilder.Entity<Status>().HasData(new Status { Id = 1, Name = "UpComing" }, new Status { Id = 2, Name = "Completed" }, new Status { Id = 3, Name = "Cancelled" });
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
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCenter> ServiceCenters { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ServiceSpecialist> ServiceSpecialists { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCenter> ProductCenters { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    }
}
