namespace BeautyPlanet.DTOs
{
    public class CreateImage
    {

       // public string Name { get; set; }
        public int GalleryId { get; set; }

    }
    public class ImageDTO 
    {
 
        public string ImageUrl { get; set; }
    }
    public class ImageFile
    {
        public CreateImage Create { get; set; }
        public IFormFile Files { get; set; }

    }
}
