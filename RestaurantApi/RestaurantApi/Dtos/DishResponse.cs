using RestaurantApi.Dishes;

namespace RestaurantApi.Dtos
{
    // Representation d'un plat dans les reponses de l'API.
    public class DishResponse
    {
        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public string Category { get; set; } = "";

        public int PreparationTimeMinutes { get; set; }

        public static DishResponse From(IDish dish) => new()
        {
            Name = dish.Name,
            Price = dish.Price,
            Category = dish.Category.ToString(),
            PreparationTimeMinutes = dish.PreparationTimeMinutes
        };
    }
}
