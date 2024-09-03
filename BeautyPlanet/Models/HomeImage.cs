using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class HomeImage
    {
        [Key]
        public int Id { get; set; }
        public List<string>ImageUrl { get; set; }
    }
}
