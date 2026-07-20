using RestaurantApi.Models;

namespace RestaurantApi.Dishes
{
    // Produit du pattern Factory : contrat commun a tous les plats.
    public interface IDish
    {
        string Name { get; }

        decimal Price { get; }

        int PreparationTimeMinutes { get; }

        DishCategory Category { get; }
    }
}
