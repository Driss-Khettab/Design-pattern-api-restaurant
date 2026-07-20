using RestaurantApi.Dishes;
using RestaurantApi.Factories;
using RestaurantApi.Models;

namespace RestaurantApi.Configuration
{
    // Singleton : une seule instance, partagee dans toute l'application.
    // Lazy<T> garantit une initialisation unique et thread-safe.
    public sealed class RestaurantConfiguration
    {
        private static readonly Lazy<RestaurantConfiguration> _instance =
            new(() => new RestaurantConfiguration());

        public static RestaurantConfiguration Instance => _instance.Value;

        public string RestaurantName { get; }

        public string OpeningHours { get; }

        public IReadOnlyList<IDish> Menu { get; }

        // Constructeur prive : empeche toute autre instanciation.
        private RestaurantConfiguration()
        {
            RestaurantName = "Le Gourmet";
            OpeningHours = "11:00 - 23:00";
            Menu = BuildMenu();
        }

        // Le menu est construit via les factories (pattern Factory).
        private static List<IDish> BuildMenu()
        {
            var provider = new DishFactoryProvider();

            return new List<IDish>
            {
                provider.GetFactory(DishCategory.Starter).CreateDish("Caesar Salad", 8.50m, 10),
                provider.GetFactory(DishCategory.Starter).CreateDish("Onion Soup", 7.00m, 12),
                provider.GetFactory(DishCategory.MainCourse).CreateDish("Grilled Salmon", 18.00m, 25),
                provider.GetFactory(DishCategory.MainCourse).CreateDish("Beef Burger", 15.50m, 20),
                provider.GetFactory(DishCategory.Dessert).CreateDish("Chocolate Cake", 6.50m, 5),
                provider.GetFactory(DishCategory.Beverage).CreateDish("Sparkling Water", 3.00m, 1)
            };
        }
    }
}
