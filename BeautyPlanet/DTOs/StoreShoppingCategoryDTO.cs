using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class StoreShoppingCategoryDTO
    {
        public int Store { get; set; }
        public int ShoppingCategoryId { get; set; }
    }
    public class GetStoreCategory
    {
        public int Id { get; set; }
        public Store Store { get; set; }
        public ShoppingCategory ShoppingCategory { get; set; }
    }
}
