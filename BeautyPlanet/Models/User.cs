using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class User:Person
    {
       
       public ICollection<Center>? Centers { get; set; }


        public int Point { get; set; } = 0;
        public int Age { get; set; } = 18;

    }
}
