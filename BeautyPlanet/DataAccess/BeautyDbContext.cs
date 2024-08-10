using BeautyPlanet.Models;
using BeautyPlanet.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
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
                (ss => ss.HasOne(prop => prop.Specialist).WithMany().HasForeignKey(prop => prop.SpecialistId),
                ss => ss.HasOne(prop => prop.Service).WithMany().HasForeignKey(prop => prop.ServiceId),
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
            modelBuilder.Entity<Center>().HasMany(u => u.UserFavorate).WithMany(c => c.FavorateCenter).UsingEntity<Favorate>(
                uc => uc.HasOne(prop => prop.User).WithMany().HasForeignKey(prop => prop.UserId),
                uc => uc.HasOne(prop => prop.Center).WithMany().HasForeignKey(prop => prop.CenterId),
                uc => uc.HasIndex(prod => new { prod.CenterId, prod.UserId })
               );
            modelBuilder.Entity<User>().HasMany(p => p.Posts).WithMany(u => u.Users).UsingEntity<UserPost>(
                up => up.HasOne(prop => prop.Post).WithMany().HasForeignKey(prop => prop.PostId),
                up => up.HasOne(prop => prop.User).WithMany().HasForeignKey(prop => prop.UserId),
                up => up.HasIndex(prop => new { prop.UserId, prop.PostId }));
            modelBuilder.Entity<User>().HasMany(p => p.SavedPost).WithMany(u => u.UserSaved).UsingEntity<UserSavedPost>(
                up => up.HasOne(prop => prop.Post).WithMany().HasForeignKey(prop => prop.PostId),
                up => up.HasOne(prop => prop.User).WithMany().HasForeignKey(prop => prop.UserId),
                up => up.HasIndex(prop => new { prop.UserId, prop.PostId }));
            modelBuilder.Entity<User>().HasMany(C=>C.Comments).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<Comment>().HasMany(p => p.LikeUser).WithMany(u => u.LikeComment).UsingEntity<UserComment>(
                up => up.HasOne(prop => prop.UserLike).WithMany().HasForeignKey(prop => prop.UserId).OnDelete(DeleteBehavior.Restrict),
                up => up.HasOne(prop => prop.Comment).WithMany().HasForeignKey(prop => prop.CommentId).OnDelete(DeleteBehavior.Restrict),
               up => up.HasIndex(prop => new { prop.UserId, prop.CommentId }));
            modelBuilder.Entity<Center>()
            .HasMany(u => u.Appointments)
            .WithOne(o => o.Center)
            .HasForeignKey(o => o.CenterId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Center>().Property(w => w.WorkingTime).HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>()
           );
            modelBuilder.Entity<Center>().Property(w => w.WorkingTime).HasDefaultValue(new List<string> { "monday - friday   , 08:00 am - 10:00 pm ",
            "saturday - sunday   , 08:00 am - 10:00 pm "});
            modelBuilder.Entity<Center>().HasMany(ca => ca.Categories).WithMany(c => c.Centers).UsingEntity<CenterCategory>(
                cc => cc.HasOne(prod => prod.Category).WithMany().HasForeignKey(prod=>prod.CategoryId),
                cc=>cc.HasOne(prod=>prod.Center).WithMany().HasForeignKey(prod=>prod.CenterId),
                cc=>cc.HasIndex(prod=>new { prod.CenterId,prod.CategoryId}));
            modelBuilder.Entity<CenterType>().HasData(new CenterType { Id = 1, Name = "BeautyCenter" }, new CenterType { Id = 2, Name = "Store" });

            modelBuilder.Entity<Status>().HasData(new Status { Id = 1, Name = "UpComing" }, new Status { Id = 2, Name = "Completed" }, new Status { Id = 3, Name = "Cancelled" });
            modelBuilder.Entity<Colors>().HasData(new Colors { Id = 10000, Name = "No Color" }, new Colors { Id = 1, Name = "#000000" }, new Colors { Id = 2, Name = "#FF0000" }, new Colors { Id = 3, Name = "#00ff00" });
            modelBuilder.Entity<Sizes>().HasData(new Sizes { Id=10000,Name="No Size"},new Sizes { Id = 1, Name = "S" }, new Sizes { Id = 2, Name = "M" }, new Sizes { Id = 3, Name = "L" });
            modelBuilder.Entity<Rate>().HasData(new Rate { Id = 1, TheRate = 1.0 }, new Rate { Id = 2, TheRate = 1.5 }, new Rate { Id = 3, TheRate = 2.0 }, new Rate { Id = 4, TheRate = 2.5 }, new Rate { Id = 5, TheRate = 3.0 }, new Rate { Id = 6, TheRate = 3.5 }, new Rate { Id = 7, TheRate = 4.0 }, new Rate { Id = 8, TheRate = 4.5 }, new Rate { Id = 9, TheRate = 5.0 });
            modelBuilder.Entity<Distance>().HasData(new Distance { Id = 1, From = 0.0, To = 10.0, FromTo = " < 10 km" }, new Distance { Id = 2, From = 10.0, To = 15.0, FromTo = " 10 - 15 km" }
            , new Distance { Id = 3, From = 15.0, To = 20.0, FromTo = " 15 - 20 km" }, new Distance { Id = 4, From = 20.0, To = 25.0, FromTo = " 20 - 25 km" }, new Distance { Id = 5, From = 25.0, To = 30.0, FromTo = " 25 - 30 km" });
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
        public DbSet<Favorate> Favorates { get; set; }
        public DbSet<CenterCategory> CenterCategories { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<Notification>Notifications { get; set; }
        public DbSet<TimeSlot>TimeSlots { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserSavedPost>UserSavedPosts { get; set; }
    }
}
