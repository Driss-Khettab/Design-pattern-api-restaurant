using RestaurantApi.Models;

namespace RestaurantApi.Observers
{
    // Observer : un service notifie des evenements d'une commande.
    public interface IOrderObserver
    {
        string Name { get; }

        void Update(Order order, OrderEvent orderEvent);
    }
}
