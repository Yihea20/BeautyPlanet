using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ProductCenter
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Centerr { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Productt { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts{get;set;}
    }
}
