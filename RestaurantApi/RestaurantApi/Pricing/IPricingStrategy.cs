using RestaurantApi.Dishes;

namespace RestaurantApi.Pricing
{
    // Contrat commun a toutes les politiques de tarification.
    public interface IPricingStrategy
    {
        decimal CalculatePrice(IReadOnlyList<IDish> items);

        string GetDescription();
    }
}
