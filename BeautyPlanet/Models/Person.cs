using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Person:IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? ImageURL { get; set; }
        public string ProfileImageURL { get; set; }
        [ForeignKey(nameof(Gallery))]
        public int? GalleryId { get; set; }
        public Gallery? Gallery { get; set; }
    }
}
