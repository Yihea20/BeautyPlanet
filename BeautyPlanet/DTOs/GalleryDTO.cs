using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class GalleryDTO
    {
        public string GallaryName { get; set; }
    }
    public class GetGallery:GalleryDTO
    {
        public int Id { get; set; }
        public ICollection<ImageDTO> Images { get; set; }

    }
    public class GalleryFile
    {

        public int Id { get; set; }
        public IFormFile Files { get; set; }
    }
}
