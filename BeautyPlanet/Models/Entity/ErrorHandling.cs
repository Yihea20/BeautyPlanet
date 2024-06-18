using Newtonsoft.Json;

namespace BeautyPlanet.Models.Entity
{
    public class ErrorHandling
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
