using RestaurantApi.Dishes;

namespace RestaurantApi.Factories
{
    public class BeverageFactory : DishFactory
    {
        public override IDish CreateDish(string name, decimal price, int preparationTimeMinutes)
            => new Beverage(name, price, preparationTimeMinutes);
    }
}
