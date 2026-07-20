using RestaurantApi.Dishes;
using RestaurantApi.Observers;
using RestaurantApi.States;

namespace RestaurantApi.Models
{
    // Order joue deux roles :
    //  - Contexte du pattern State (workflow de la commande)
    //  - Sujet du pattern Observer (notifie les services abonnes)
    public class Order
    {
        private readonly List<IOrderObserver> _observers = new();

        private OrderState _state;

        public string Id { get; } = Guid.NewGuid().ToString();

        public int TableNumber { get; }

        public List<IDish> Items { get; }

        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; } = DateTime.Now;

        public Order(int tableNumber, List<IDish> items)
        {
            TableNumber = tableNumber;
            Items = items;
            _state = new ReceivedState(this);
        }

        // Observer : abonnement / desabonnement
        public void Subscribe(IOrderObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(OrderEvent orderEvent)
        {
            foreach (var observer in _observers)
                observer.Update(this, orderEvent);
        }

        // State : le contexte applique la transition retournee par l'etat courant
        public void Advance()
        {
            var newState = _state.Advance();
            if (!ReferenceEquals(newState, _state))
                SetState(newState);
        }

        public void SetState(OrderState newState)
        {
            Console.WriteLine($"  -> State transition: {_state.GetStateName()} -> {newState.GetStateName()}");
            _state = newState;
        }

        public string Status => _state.GetStateName();
    }
}
