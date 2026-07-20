using RestaurantApi.Models;
using RestaurantApi.Observers;

namespace RestaurantApi.States
{
    // Prete : tous les plats sont prets, en attente du service.
    public class ReadyState : OrderState
    {
        public ReadyState(Order order) : base(order) { }

        public override OrderState Advance()
        {
            _order.Notify(OrderEvent.Served);
            return new ServedState(_order);
        }

        public override string GetStateName() => "Ready";
    }
}
