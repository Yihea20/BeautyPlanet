using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Admin:Person
    {

       
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; }
      


    }
}
