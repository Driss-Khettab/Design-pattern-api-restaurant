using RestaurantApi.Models;

namespace RestaurantApi.Observers
{
    // Service Facturation : notifie de la creation (montant) et du paiement.
    public class BillingService : IOrderObserver
    {
        public string Name => "Facturation";

        public void Update(Order order, OrderEvent orderEvent)
        {
            if (orderEvent == OrderEvent.Created)
                Console.WriteLine($"[Facturation] Commande #{order.Id} enregistree, montant : {order.TotalPrice} euros.");
            else if (orderEvent == OrderEvent.Paid)
                Console.WriteLine($"[Facturation] Commande #{order.Id} reglee.");
        }
    }
}
