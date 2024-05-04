using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace BeautyPlanet.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int Conter { get; set; } = 0;
        public int EarnPoint { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(ShoppingCategory))]
        public int ShoppingCategoryId { get; set; }
        public ShoppingCategory ShoppingCategoryy { get; set; }
        public ICollection<Colors> Colors { get; set; }
       public ICollection<Sizes> Sizes { get; set; }
        public ICollection<Center> Centers { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
