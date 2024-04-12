using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ServiceSpecialist))]
        public int ServiceSpecialistId { get; set; }
        public ServiceSpecialist ServiceSpecialistt { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Userr { get; set; }
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public Status Statuss { get; set; }
        public DateTime? DateTime { get; set; }

    }
}
