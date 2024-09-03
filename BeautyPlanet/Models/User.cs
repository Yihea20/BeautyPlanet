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
        public int Point { get; set; } = 0;
        public DateTime? Birthday { get; set; }
        public List<DateTime> CancelDate { get; set; }=new List<DateTime>();
        public int OrderCount { get; set; } = 0;
        public int FavoriteCount { get; set; } = 0;
        public bool Ban { get; set; }
        public ICollection<Center>? FavorateCenter { get; set; }
        public int Like { get; set; } = 0;
      //  public string? Address{get;set;}
        public ICollection<Post>Posts { get; set; }
        public ICollection<Post>SavedPost { get; set; }

        public ICollection<Comment> LikeComment { get; set; }
    }
}
