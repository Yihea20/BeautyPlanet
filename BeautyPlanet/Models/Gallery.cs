using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
