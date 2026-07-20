using RestaurantApi.Models;

namespace RestaurantApi.Dishes
{
    // Produit concret : une entree.
    public class Starter : IDish
    {
        public string Name { get; }

        public decimal Price { get; }

        public int PreparationTimeMinutes { get; }

        public DishCategory Category => DishCategory.Starter;

        public Starter(string name, decimal price, int preparationTimeMinutes)
        {
            Name = name;
            Price = price;
            PreparationTimeMinutes = preparationTimeMinutes;
        }
    }
}
