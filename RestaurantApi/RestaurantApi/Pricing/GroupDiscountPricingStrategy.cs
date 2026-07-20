using RestaurantApi.Dishes;

namespace RestaurantApi.Pricing
{
    // Reduction groupe : reduction de 15% si la commande depasse 50 euros.
    public class GroupDiscountPricingStrategy : IPricingStrategy
    {
        private const decimal Threshold = 50m;

        private const decimal DiscountRate = 0.15m;

        public decimal CalculatePrice(IReadOnlyList<IDish> items)
        {
            var total = items.Sum(item => item.Price);
            return total > Threshold
                ? total * (1 - DiscountRate)
                : total;
        }

        public string GetDescription() => "Group discount (-15% if total > 50 euros)";
    }
}
