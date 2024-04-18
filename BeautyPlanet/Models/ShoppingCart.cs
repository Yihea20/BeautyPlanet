using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ProductCenter))]
        public int ProductCenterId { get; set; }
        public ProductCenter ProductCenterr { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Userr { get; set; }
        public int Count { get; set; }
    }
}
