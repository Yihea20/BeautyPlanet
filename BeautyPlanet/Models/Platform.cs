using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get;set; }
        public int Phone { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}
