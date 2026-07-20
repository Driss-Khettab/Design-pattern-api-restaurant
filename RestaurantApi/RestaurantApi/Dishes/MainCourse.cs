using RestaurantApi.Models;

namespace RestaurantApi.Dishes
{
    // Produit concret : un plat principal.
    public class MainCourse : IDish
    {
        public string Name { get; }

        public decimal Price { get; }

        public int PreparationTimeMinutes { get; }

        public DishCategory Category => DishCategory.MainCourse;

        public MainCourse(string name, decimal price, int preparationTimeMinutes)
        {
            Name = name;
            Price = price;
            PreparationTimeMinutes = preparationTimeMinutes;
        }
    }
}
