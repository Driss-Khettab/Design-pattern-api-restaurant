using RestaurantApi.Models;

namespace RestaurantApi.Dtos
{
    // Representation d'une commande dans les reponses de l'API.
    public class OrderResponse
    {
        public string Id { get; set; } = "";

        public int TableNumber { get; set; }

        public List<DishResponse> Items { get; set; } = new();

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public static OrderResponse From(Order order) => new()
        {
            Id = order.Id,
            TableNumber = order.TableNumber,
            Items = order.Items.Select(DishResponse.From).ToList(),
            TotalPrice = order.TotalPrice,
            Status = order.Status,
            CreatedAt = order.CreatedAt
        };
    }
}
