using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Distance
    {
        [Key]
        public int Id { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public string FromTo { get; set; }
    }
}
