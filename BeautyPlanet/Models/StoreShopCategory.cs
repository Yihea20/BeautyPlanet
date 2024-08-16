using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class StoreShopCategory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [ForeignKey(nameof(ShoppingCategory))]
        public int ShoppingCategoryId { get; set; }
        public ShoppingCategory ShoppingCategory { get; set; }
    }
}
