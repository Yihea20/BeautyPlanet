using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Specialist))]
        public string SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
        [ForeignKey(nameof(Service))]
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public Center? Center { get; set; }
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string? CostomServiceName { get; set; }
        public string? description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateTime { get; set; }

    }
}
