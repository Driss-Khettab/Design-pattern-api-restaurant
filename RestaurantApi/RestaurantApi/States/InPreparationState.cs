using RestaurantApi.Models;
using RestaurantApi.Observers;

namespace RestaurantApi.States
{
    // En preparation : la cuisine a commence a preparer.
    public class InPreparationState : OrderState
    {
        public InPreparationState(Order order) : base(order) { }

        public override OrderState Advance()
        {
            _order.Notify(OrderEvent.Ready);
            return new ReadyState(_order);
        }

        public override string GetStateName() => "InPreparation";
    }
}
