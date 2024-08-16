using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class UserSavedPost
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey(nameof(Specialist))]
        public string? SpecialistId { get; set; }
        public Specialist? SpecialistSave{ get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
