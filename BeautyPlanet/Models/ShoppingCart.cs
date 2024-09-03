using BeautyPlanet.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<ProductCenterColorSize> ProductCenterColorSize { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public int TotalPrice { get; set; }
        [ForeignKey(nameof(OrderStatus))]
        public int? OrderStatusId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
