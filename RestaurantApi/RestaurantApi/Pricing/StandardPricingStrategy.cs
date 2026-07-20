using RestaurantApi.Dishes;

namespace RestaurantApi.Pricing
{
    // Tarif standard : somme des prix de base.
    public class StandardPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(IReadOnlyList<IDish> items) => items.Sum(item => item.Price);

        public string GetDescription() => "Standard price (sum of items)";
    }
}
