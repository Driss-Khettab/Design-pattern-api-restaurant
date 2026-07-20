using RestaurantApi.Models;

namespace RestaurantApi.Observers
{
    // Service Cuisine : notifie des nouvelles commandes et du debut de preparation.
    public class KitchenService : IOrderObserver
    {
        public string Name => "Cuisine";

        public void Update(Order order, OrderEvent orderEvent)
        {
            if (orderEvent == OrderEvent.Created)
                Console.WriteLine($"[Cuisine] Nouvelle commande #{order.Id} (table {order.TableNumber}) a preparer.");
            else if (orderEvent == OrderEvent.PreparationStarted)
                Console.WriteLine($"[Cuisine] Debut de preparation de la commande #{order.Id}.");
        }
    }
}
