using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Notification
    {
        [Key]
        public int Id { set; get; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string? DeviceToken { get; set; }
        [ForeignKey(nameof(Service))]
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
