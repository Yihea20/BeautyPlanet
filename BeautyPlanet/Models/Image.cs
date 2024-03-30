using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey(nameof(Galary))]
        public int GalaryId { get; set; }
        public Gallery Galary { get; set; }
    }
}
