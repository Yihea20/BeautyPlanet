using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int PhoneNumber { get; set; }
            public string ImageUrl { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
            public ICollection<ProductCenterColorSize> Products { get; set; }
        public ICollection<ShoppingCategory>ShoppingCategories { get; set; }
    }
}
