using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class User:Person
    {
       
        public ICollection<Center>? Centers { get; set; }
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public IList<DateTime>? Times { get; set; } = new List<DateTime>();
        public int Point { get; set; } 
        public int Age { get; set; } 
        

    }
}
