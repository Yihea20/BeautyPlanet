using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
