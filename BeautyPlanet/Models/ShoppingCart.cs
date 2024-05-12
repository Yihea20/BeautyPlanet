using BeautyPlanet.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
<<<<<<< HEAD
        [Forig]
        public int CenterId { get; set; }
        public Center Centerr { get; set; }
        public ICollection<Product>Products{get;set;}
=======
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; } 
        public ICollection<ProductColorSize> Products { get; set; }
>>>>>>> cfebb0d05fe68bd19ed3219b8876c8ae9638ead3
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        public int Count { get; set; }
    }
}
