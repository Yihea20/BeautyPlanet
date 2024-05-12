using BeautyPlanet.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Forig]
        public int CenterId { get; set; }
        public Center Centerr { get; set; }
        public ICollection<Product>Products{get;set;}
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Userr { get; set; }
        public int Count { get; set; }
    }
}
