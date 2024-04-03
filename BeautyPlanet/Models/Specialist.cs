using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Specialist:Person
    {

        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; }
     
        public int Rate { get; set; }
        public string Exparences { get; set; }
        
    }
}
