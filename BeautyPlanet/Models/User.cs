using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class User : Person
    {

        // public ICollection<Center>? Centers { get; set; }
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public int? Point { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Center>? FavorateCenter { get; set; }
        public int? Like { get; set; }
        public string? Address{get;set;}
        public ICollection<Post>Posts { get; set; }
        public ICollection<Post>SavedPost { get; set; }

        public ICollection<Comment> LikeComment { get; set; }
    }
}
