using RestaurantApi.Dishes;
using RestaurantApi.Models;

namespace RestaurantApi.Pricing
{
    // Formule menu : prix fixe de 25 euros si la commande contient
    // une entree + un plat principal + un dessert.
    public class MenuFormulaPricingStrategy : IPricingStrategy
    {
        private const decimal FixedPrice = 25m;

        public decimal CalculatePrice(IReadOnlyList<IDish> items)
        {
            var hasStarter = items.Any(item => item.Category == DishCategory.Starter);
            var hasMainCourse = items.Any(item => item.Category == DishCategory.MainCourse);
            var hasDessert = items.Any(item => item.Category == DishCategory.Dessert);

            return hasStarter && hasMainCourse && hasDessert
                ? FixedPrice
                : items.Sum(item => item.Price);
        }

        public string GetDescription() => "Menu formula (fixed 25 euros for starter + main + dessert)";
    }
}
