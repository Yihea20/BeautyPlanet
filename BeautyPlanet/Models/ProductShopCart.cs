using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ProductShopCart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ProductCenterColorSize))]
        public int ProductCenterColorSizeId { get; set; }
        public ProductCenterColorSize ProductCenterColorSize { get; set; }
        [ForeignKey(nameof(ShoppingCart))]
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int count { get; set; }
    }
}
