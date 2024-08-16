using BeautyPlanet.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Center))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<ProductCenterColorSize> ProductCenterColorSize { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public int TotalPrice { get; set; }
        [ForeignKey(nameof(Status))]
        public int? StatusId { get; set; }
        public Status Status { get; set; }
    }
}
