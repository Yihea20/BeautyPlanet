namespace BeautyPlanet.Models
{
    public class ListImage
    {
        public int Id { get; set; }
        public IList<string>ImageUrl { get; set; }=new List<string>();
    }
}
