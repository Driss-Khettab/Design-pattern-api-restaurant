using RestaurantApi.Models;

namespace RestaurantApi.Factories
{
    // Centralise le choix de la factory selon la categorie.
    // Ajouter une categorie = 1 produit + 1 factory + 1 ligne ici.
    public class DishFactoryProvider
    {
        private readonly Dictionary<DishCategory, DishFactory> _factories = new()
        {
            { DishCategory.Starter, new StarterFactory() },
            { DishCategory.MainCourse, new MainCourseFactory() },
            { DishCategory.Dessert, new DessertFactory() },
            { DishCategory.Beverage, new BeverageFactory() }
        };

        public DishFactory GetFactory(DishCategory category)
        {
            return _factories[category];
        }
    }
}
