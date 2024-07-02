using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Center
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Description { get; set; }
        public string? WebSiteUrl { get; set; }
        [ForeignKey(nameof(Admin))]
        public string? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public int? Rate { get; set; }
        public string? ImageUrl { get; set; }
        //public IList<string>? GalleryImage { get; set; } = new List<string>();
        [ForeignKey(nameof(Platform))]
        public int? PlatformId { get; set; }
        public Platform? Platform { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Specialist> Specialists { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<User> UserFavorate { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Post>Posts { get; set; }
        public ICollection<Appointment>Appointments { get; set; }
        //public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
