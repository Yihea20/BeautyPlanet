using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class NotificationDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string DeviceToken { get; set; }
        public int? ServiceId { get; set; }
    }
    public class GetNotificationDTO
    {
       
        public int Id { set; get; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string? DeviceToken { get; set; }
        public GetServiceDTO? Service { get; set; }
    }
}
