using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; } 
        public ICollection<ProductColorSize> Products { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public int Count { get; set; }
    }
}
