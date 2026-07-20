using RestaurantApi.Dishes;

namespace RestaurantApi.Factories
{
    public class DessertFactory : DishFactory
    {
        public override IDish CreateDish(string name, decimal price, int preparationTimeMinutes)
            => new Dessert(name, price, preparationTimeMinutes);
    }
}
