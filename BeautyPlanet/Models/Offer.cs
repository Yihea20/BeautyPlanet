using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Offer
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(ServiceCenter))]
        public int ServiceCenterId { get; set; }
        public ServiceCenter ServiceCente { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;
    }
}
