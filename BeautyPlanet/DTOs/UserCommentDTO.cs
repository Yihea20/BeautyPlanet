using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class UserCommentDTO
    {

        public string? UserId { get; set; }
        public string? SpecialistId { get; set; }
        public int CommentId { get; set; }
    }
}
