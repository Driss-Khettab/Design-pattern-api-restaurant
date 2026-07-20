using RestaurantApi.Dishes;

namespace RestaurantApi.Factories
{
    // Creator abstrait du pattern Factory : declare la methode de creation.
    public abstract class DishFactory
    {
        public abstract IDish CreateDish(string name, decimal price, int preparationTimeMinutes);
    }
}
