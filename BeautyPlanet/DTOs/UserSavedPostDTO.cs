using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class UserSavedPostDTO
    {

        public string? UserId { get; set; }

        public string? SpecialistId { get; set; }
        public int PostId { get; set; }
    }
    public class GetSavedPost
    {
     
        public int Id { get; set; }
        public GetCenterPost Post { get; set; }
    }
}
