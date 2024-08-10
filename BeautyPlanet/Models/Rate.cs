using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        public double TheRate { get; set; }
    }
}
