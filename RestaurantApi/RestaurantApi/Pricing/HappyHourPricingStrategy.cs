using RestaurantApi.Dishes;

namespace RestaurantApi.Pricing
{
    // Happy Hour : reduction de 20% entre 15h et 19h.
    public class HappyHourPricingStrategy : IPricingStrategy
    {
        private const decimal DiscountRate = 0.20m;

        private const int StartHour = 15;

        private const int EndHour = 19;

        public decimal CalculatePrice(IReadOnlyList<IDish> items)
        {
            var total = items.Sum(item => item.Price);
            var hour = DateTime.Now.Hour;
            return hour >= StartHour && hour < EndHour
                ? total * (1 - DiscountRate)
                : total;
        }

        public string GetDescription() => "Happy Hour (-20% between 15h and 19h)";
    }
}
