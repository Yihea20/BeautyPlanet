using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ProductCenterColorSize
    {
        [Key]
        public int Id { get; set; }
        public IList<string> ImageUrl { get; set; } = new List<string>();
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public string? Type { get; set; }
        public int Rate { get; set; }
        public int Conter { get; set; } = 0;
        public int EarnPoint { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Colors))]
        public int? ColorId { get; set; }
        public Colors? Color { get; set; }
        [ForeignKey(nameof(Sizes))]
        public int? SizeId { get; set; }
        public Sizes? Size { get; set; }
        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; } 
        public int? Count { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public ICollection<Review> Reviews { get; set; }
        [ForeignKey(nameof(ShoppingCategory))]
        public int? ShoppingCategoryId { get; set; }
        public ShoppingCategory ShoppingCategory { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    

    }
}
