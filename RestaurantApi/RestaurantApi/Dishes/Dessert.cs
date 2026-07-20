using RestaurantApi.Models;

namespace RestaurantApi.Dishes
{
    // Produit concret : un dessert.
    public class Dessert : IDish
    {
        public string Name { get; }

        public decimal Price { get; }

        public int PreparationTimeMinutes { get; }

        public DishCategory Category => DishCategory.Dessert;

        public Dessert(string name, decimal price, int preparationTimeMinutes)
        {
            Name = name;
            Price = price;
            PreparationTimeMinutes = preparationTimeMinutes;
        }
    }
}
