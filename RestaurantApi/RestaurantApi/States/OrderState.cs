using RestaurantApi.Models;

namespace RestaurantApi.States
{
    // Classe abstraite de base du pattern State.
    // Approche 2 : chaque etat retourne le prochain etat, le contexte applique la transition.
    public abstract class OrderState
    {
        protected Order _order;

        public OrderState(Order order)
        {
            _order = order;
        }

        public abstract OrderState Advance();

        public abstract string GetStateName();
    }
}
