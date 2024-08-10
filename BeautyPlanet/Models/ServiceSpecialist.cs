using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ServiceSpecialist
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        [ForeignKey(nameof(Specialist))]
        public string SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
    }
}
