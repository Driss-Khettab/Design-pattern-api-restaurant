using RestaurantApi.Models;
using RestaurantApi.Observers;

namespace RestaurantApi.States
{
    // Servie : commande livree a la table, en attente de paiement.
    public class ServedState : OrderState
    {
        public ServedState(Order order) : base(order) { }

        public override OrderState Advance()
        {
            _order.Notify(OrderEvent.Paid);
            return new PaidState(_order);
        }

        public override string GetStateName() => "Served";
    }
}
