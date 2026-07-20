using RestaurantApi.Models;

namespace RestaurantApi.Dishes
{
    // Produit concret : une boisson.
    public class Beverage : IDish
    {
        public string Name { get; }

        public decimal Price { get; }

        public int PreparationTimeMinutes { get; }

        public DishCategory Category => DishCategory.Beverage;

        public Beverage(string name, decimal price, int preparationTimeMinutes)
        {
            Name = name;
            Price = price;
            PreparationTimeMinutes = preparationTimeMinutes;
        }
    }
}
