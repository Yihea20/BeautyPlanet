using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey(nameof(Gallery))]
        public int GalleryId { get; set; }
        public Gallery Galler { get; set; }
    }
}
