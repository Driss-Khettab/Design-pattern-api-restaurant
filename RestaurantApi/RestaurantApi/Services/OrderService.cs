using RestaurantApi.Dishes;
using RestaurantApi.Dtos;
using RestaurantApi.Factories;
using RestaurantApi.Models;
using RestaurantApi.Observers;
using RestaurantApi.Pricing;
using RestaurantApi.Repositories;

namespace RestaurantApi.Services
{
    // Orchestre la creation et l'avancement des commandes.
    // Assemble les patterns : Factory (plats), Strategy (prix), Observer (services), State (workflow).
    public class OrderService
    {
        private readonly OrderRepository _repository;

        private readonly DishFactoryProvider _dishFactoryProvider;

        private readonly PricingStrategyProvider _pricingStrategyProvider;

        private readonly IReadOnlyList<IOrderObserver> _observers;

        public OrderService(
            OrderRepository repository,
            DishFactoryProvider dishFactoryProvider,
            PricingStrategyProvider pricingStrategyProvider,
            IEnumerable<IOrderObserver> observers)
        {
            _repository = repository;
            _dishFactoryProvider = dishFactoryProvider;
            _pricingStrategyProvider = pricingStrategyProvider;
            _observers = observers.ToList();
        }

        // Retourne null si la politique de tarification est inconnue.
        public Order? CreateOrder(CreateOrderRequest request)
        {
            var strategy = _pricingStrategyProvider.GetStrategy(request.PricingStrategy);
            if (strategy is null)
                return null;

            var items = new List<IDish>();
            foreach (var itemRequest in request.Items)
            {
                var factory = _dishFactoryProvider.GetFactory(itemRequest.Category);
                items.Add(factory.CreateDish(itemRequest.Name, itemRequest.Price, itemRequest.PreparationTimeMinutes));
            }

            var order = new Order(request.TableNumber, items);

            foreach (var observer in _observers)
                order.Subscribe(observer);

            var calculator = new PriceCalculator(strategy);
            order.TotalPrice = calculator.CalculatePrice(items);

            order.Notify(OrderEvent.Created);

            _repository.Add(order);
            return order;
        }

        public Order? GetOrder(string id)
        {
            return _repository.GetById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        // Retourne null si la commande n'existe pas.
        public Order? AdvanceOrder(string id)
        {
            var order = _repository.GetById(id);
            if (order is null)
                return null;

            order.Advance();
            return order;
        }
    }
}
