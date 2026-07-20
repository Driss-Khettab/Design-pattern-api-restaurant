using RestaurantApi.Models;
using RestaurantApi.Observers;

namespace RestaurantApi.States
{
    // Recue : commande creee, en attente de preparation.
    public class ReceivedState : OrderState
    {
        public ReceivedState(Order order) : base(order) { }

        public override OrderState Advance()
        {
            _order.Notify(OrderEvent.PreparationStarted);
            return new InPreparationState(_order);
        }

        public override string GetStateName() => "Received";
    }
}
