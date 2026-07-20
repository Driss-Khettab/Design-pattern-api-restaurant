using RestaurantApi.Models;

namespace RestaurantApi.Dtos
{
    // Un plat dans le corps de la requete POST /api/orders.
    public class CreateOrderItemRequest
    {
        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public DishCategory Category { get; set; }

        public int PreparationTimeMinutes { get; set; }
    }
}
