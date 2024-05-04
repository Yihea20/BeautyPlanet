namespace BeautyPlanet.DTOs
{
    public class ListImageDTO
    {
        public List<string> ImageUrl { get; set; }
    }
    public class Files
    {
        public IList<IFormFile> File { get; set; }
    }
}
