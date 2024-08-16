using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class CommentDTO
    {
       
        public string Comments { get; set; }
        public DateTime CommentTime { get; set; }= DateTime.Now;
        public string? PersonId { get; set; }
        public int PostId { get; set; }
        
    }
    public class GetCommentDTO
    {


        public string? PersonId { get; set; }
        public int PostId { get; set; }

    }
    public class GetComment
    {
        [Key]
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime CommentTime { get; set; }
        public int? Like { get; set; }

        public UserReviews Person { get; set; }
        public bool IsLiked { get; set; }
       // public Post Post { get; set; }
    }
    public class GetSpComment
    {
        [Key]
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime CommentTime { get; set; }
        public int? Like { get; set; }
        public GetSpecialistDTO Specialist { get; set; }
        public bool IsLiked { get; set; }
        // public Post Post { get; set; }
    }
    
}
