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
        public int OfferPercent { get; set; }
        public int Rate { get; set; }
        [ForeignKey(nameof(Colors))]
        public int? ColorId { get; set; }
        public Colors? Color { get; set; }
        [ForeignKey(nameof(Sizes))]
        public int? SizeId { get; set; }
        public Sizes? Sizess { get; set; }
        public ICollection<Center> Centers { get; set; }
    }
}
