using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string subject { get; set; }
        public IList<string> ImageUrl { get; set; } = new List<string>();
        public int likes { get; set; } = 0;
        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public Center? Center { get; set; }
        [ForeignKey(nameof(Specialist))]
        public string? SpecialistId { get; set; }
        public Specialist? Specialist { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<User>Users { get; set; }
        public ICollection<User> UserSaved { get; set; }
        public ICollection<Specialist>LikedSpecialists{ get; set; }
        public ICollection<Specialist> SpecialistsSave { get; set; }
    }
}
