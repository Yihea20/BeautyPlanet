using BeautyPlanet.Models;
using BeautyPlanet.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading.Tasks.Dataflow;

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
            modelBuilder.Entity<Product>().HasMany(c => c.Centers).WithMany(p => p.Products).UsingEntity<ProductCenterColorSize>
                (pc => pc.HasOne(prop => prop.Center).WithMany().HasForeignKey(Prop => Prop.CenterId),
                pc => pc.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
                pc => pc.HasIndex(prop => new { prop.ProductId, prop.CenterId }));
            modelBuilder.Entity<Product>().HasMany(s => s.Sizes).WithMany(p => p.Products).UsingEntity<ProductCenterColorSize>(
                pc => pc.HasOne(prop => prop.Size).WithMany().HasForeignKey(prop => prop.SizeId),
                pc => pc.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
                pc => pc.HasIndex(prop => new { prop.ProductId, prop.SizeId }));
            modelBuilder.Entity<Product>().HasMany(s => s.Colors).WithMany(p => p.Products).UsingEntity<ProductCenterColorSize>(
                pc => pc.HasOne(prop => prop.Color).WithMany().HasForeignKey(prop => prop.ColorId),
                pc => pc.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
                pc => pc.HasIndex(prop => new { prop.ProductId, prop.ColorId }));
            modelBuilder.Entity<ShoppingCart>().HasMany(sh => sh.ProductCenterColorSize).WithMany(p => p.ShoppingCarts).UsingEntity<ProductShopCart>(
                psh => psh.HasOne(prod => prod.ProductCenterColorSize).WithMany().HasForeignKey(prod => prod.ProductCenterColorSizeId).OnDelete(DeleteBehavior.Restrict),
                psh => psh.HasOne(prod => prod.ShoppingCart).WithMany().HasForeignKey(prod => prod.ShoppingCartId).OnDelete(DeleteBehavior.Restrict),
                psh => psh.HasIndex(prod => new { prod.ShoppingCartId, prod.ProductCenterColorSizeId }));
            modelBuilder.Entity<CenterType>().HasData(new CenterType { Id = 1, Name = "BeautyCenter" }, new CenterType { Id = 2, Name = "Store" });

            modelBuilder.Entity<Status>().HasData(new Status { Id = 1, Name = "UpComing" }, new Status { Id = 2, Name = "Completed" }, new Status { Id = 3, Name = "Cancelled" });
            modelBuilder.Entity<Colors>().HasData(new Colors { Id = 10000, Name = "No Color" }, new Colors { Id = 1, Name = "Black" }, new Colors { Id = 2, Name = "Red" }, new Colors { Id = 3, Name = "Green" });
            modelBuilder.Entity<Sizes>().HasData(new Sizes { Id=10000,Name="No Size"},new Sizes { Id = 1, Name = "S" }, new Sizes { Id = 2, Name = "M" }, new Sizes { Id = 3, Name = "L" });

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
        public DbSet<Product> Products { get; set; }
        //public DbSet<ProductCenter> ProductCenters { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCategory> ShoppingCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<ProductCenterColorSize> ProductCenterColorSizes { get; set; }
        public DbSet<ProductShopCart> ProductShopCarts { get; set; }
        public DbSet<ListImage> ListImages { get; set; }
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<Rating>Ratings { get; set; }
    }
}
