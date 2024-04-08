using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Specialist:Person
    {

        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; } = 1;
        public Center Center { get; set; }

        public int Rate { get; set; } = 3;
        public string Exparences { get; set; } = "good";
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; } = 1;
        public Service Service { get; set; }
    }
}
