using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class ShoppingCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name {get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ProductCenterColorSize> ProductCenterColorSizes { get; set; }
        public ICollection<Store>Stores { get; set; }
    }
}
