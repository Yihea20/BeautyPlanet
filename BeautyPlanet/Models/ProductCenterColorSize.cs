using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ProductCenterColorSize
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Colors))]
        public int? ColorId { get; set; }
        public Colors? Color { get; set; }
        [ForeignKey(nameof(Sizes))]
        public int? SizeId { get; set; }
        public Sizes? Size { get; set; }
        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; } 
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? Count { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
