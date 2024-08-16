using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class UserPostDTO
    {
        public string? UserId { get; set; }
        
        public string? SpecialistId { get; set; }
        
        public int PostId { get; set; }
    }
}
