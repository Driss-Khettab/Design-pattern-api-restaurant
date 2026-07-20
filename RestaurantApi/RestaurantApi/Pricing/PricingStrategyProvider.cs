namespace RestaurantApi.Pricing
{
    // Selectionne la strategie de prix a partir de son nom (venu de la requete).
    // Ajouter une politique = 1 strategie + 1 ligne ici.
    public class PricingStrategyProvider
    {
        private readonly Dictionary<string, IPricingStrategy> _strategies = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Standard", new StandardPricingStrategy() },
            { "HappyHour", new HappyHourPricingStrategy() },
            { "GroupDiscount", new GroupDiscountPricingStrategy() },
            { "MenuFormula", new MenuFormulaPricingStrategy() }
        };

        public IPricingStrategy? GetStrategy(string name)
        {
            return _strategies.TryGetValue(name, out var strategy) ? strategy : null;
        }
    }
}
