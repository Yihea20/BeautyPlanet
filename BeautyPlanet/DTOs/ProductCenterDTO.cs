using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ProductCenterDTO
    {

        public int CenterId { get; set; }
        public int ProductId { get; set; }
        
    }
    public class GetProductCenter:ProductCenterDTO
    {

        public int Id { get; set; }
        public GetCenterDTO Centerr { get; set; }
        public GetProduct Productt { get; set; }
        public ICollection<ShoppingCartDTO> ShoppingCarts { get; set; }

    }
}
