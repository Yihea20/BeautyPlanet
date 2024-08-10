using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class TimeSlot
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
