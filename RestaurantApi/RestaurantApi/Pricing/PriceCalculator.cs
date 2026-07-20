using RestaurantApi.Dishes;

namespace RestaurantApi.Pricing
{
    // Contexte du pattern Strategy : delegue le calcul a la strategie courante.
    public class PriceCalculator
    {
        private IPricingStrategy _strategy;

        public PriceCalculator(IPricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IPricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal CalculatePrice(IReadOnlyList<IDish> items)
        {
            var total = _strategy.CalculatePrice(items);
            Console.WriteLine($"Pricing: {_strategy.GetDescription()} => {total} euros");
            return total;
        }
    }
}
