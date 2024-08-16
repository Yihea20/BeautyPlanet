using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Specialist:Person
    {

        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; } 
        public Center Center { get; set; }
        public int ?Rate { get; set; } 
        public string ?Exparences { get; set; }
        public string ?Specialization { get; set; }
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Post> LikedPosts { get; set; }
        public ICollection<Post> SavePosts { get; set; }

        public ICollection<Comment> LikeComments { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
