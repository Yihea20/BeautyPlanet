namespace BeautyPlanet.DTOs
{
    public class CreateImage
    {

        public string Name { get; set; }
        public int GalleryId { get; set; }

    }
    public class ImageDTO : CreateImage
    {
        public int Id { get; set; }
        public string? URL { get; set; }
    }
    public class ImageFile
    {
        public CreateImage Create { get; set; }
        public IFormFile file { get; set; }

    }
}
