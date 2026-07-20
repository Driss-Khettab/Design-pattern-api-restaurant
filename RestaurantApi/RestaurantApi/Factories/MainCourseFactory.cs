using RestaurantApi.Dishes;

namespace RestaurantApi.Factories
{
    public class MainCourseFactory : DishFactory
    {
        public override IDish CreateDish(string name, decimal price, int preparationTimeMinutes)
            => new MainCourse(name, price, preparationTimeMinutes);
    }
}
