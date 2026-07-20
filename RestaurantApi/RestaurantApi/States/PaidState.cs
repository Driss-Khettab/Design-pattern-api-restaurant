using RestaurantApi.Models;

namespace RestaurantApi.States
{
    // Payee : commande reglee, workflow termine. Etat final.
    public class PaidState : OrderState
    {
        public PaidState(Order order) : base(order) { }

        public override OrderState Advance()
        {
            Console.WriteLine($"  Commande #{_order.Id} deja payee : impossible d'avancer.");
            return this;
        }

        public override string GetStateName() => "Paid";
    }
}
