using RestaurantApi.Dishes;

namespace RestaurantApi.Factories
{
    public class StarterFactory : DishFactory
    {
        public override IDish CreateDish(string name, decimal price, int preparationTimeMinutes)
            => new Starter(name, price, preparationTimeMinutes);
    }
}
