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
        [ForeignKey(nameof(Person))]
        public string? DeviceToken { get; set; }
        public Person Person { get; set; }
        public string? CenterImage { get; set; }
        public string? CenterName { get; set; }

    }
}
