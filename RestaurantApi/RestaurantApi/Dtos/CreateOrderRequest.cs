namespace RestaurantApi.Dtos
{
    // Corps de la requete POST /api/orders.
    public class CreateOrderRequest
    {
        public int TableNumber { get; set; }

        public List<CreateOrderItemRequest> Items { get; set; } = new();

        // Politique de tarification : Standard, HappyHour, GroupDiscount ou MenuFormula.
        public string PricingStrategy { get; set; } = "Standard";
    }
}
