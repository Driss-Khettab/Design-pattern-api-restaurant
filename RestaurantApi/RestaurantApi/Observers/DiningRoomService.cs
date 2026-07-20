using RestaurantApi.Models;

namespace RestaurantApi.Observers
{
    // Service en Salle : notifie quand une commande est prete a servir.
    public class DiningRoomService : IOrderObserver
    {
        public string Name => "Salle";

        public void Update(Order order, OrderEvent orderEvent)
        {
            if (orderEvent == OrderEvent.Ready)
                Console.WriteLine($"[Salle] Commande #{order.Id} prete a servir (table {order.TableNumber}).");
        }
    }
}
