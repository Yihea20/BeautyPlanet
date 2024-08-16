using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class CenterPostDTO
    {
        //public int Id { get; set; }
        public string? Title { get; set; }
        public string subject { get; set; }
        public int? CenterId { get; set; }
    }
    public class SpPostDTO
    {
        // public int Id { get; set; }
        public string Title { get; set; }
        public string subject { get; set; }
        public string SpecialistId { get; set; }
    }
    public class GetCenterPost
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public IList<string> ImageUrl { get; set; } = new List<string>();
        public int likes { get; set; }

        public string? Title { get; set; }
        public bool? IsLiked { get; set; }=false;
        public bool? IsSaved { get; set; }=false;
        // public ICollection<GetComment> Comments { get; set; }
        //public GetCenterDTO? Center { get; set; }
        public GetSpecialistDTO? Specialist { get; set; }

    }
    public class GetSpPost
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public IList<string> ImageUrl { get; set; } = new List<string>();
        public int likes { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
    public class PostSpFile
    {
        public SpPostDTO SpPost { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
    public class PostCenterPost
    {

        public CenterPostDTO CenterPost { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
}
