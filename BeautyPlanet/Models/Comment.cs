using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Comments { get; set; }
        public int Like { get; set; } = 0;
        public DateTime CommentTime { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; }
        public ICollection<User> LikeUser { get; set; }
    }
}
