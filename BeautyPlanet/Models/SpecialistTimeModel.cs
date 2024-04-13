using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class SpecialistTimeModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Specialistt))]
        public string SpecialistId { get; set; }
        public Specialist Specialistt { get; set; }
        [ForeignKey(nameof(TimeModel))]
        public int TimeModelId { get; set; }
        public TimeModel TimeModell { get; set; }
    }
}
