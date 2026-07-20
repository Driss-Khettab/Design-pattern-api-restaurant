using System.Text.Json.Serialization;
using RestaurantApi.Configuration;
using RestaurantApi.Dtos;
using RestaurantApi.Factories;
using RestaurantApi.Observers;
using RestaurantApi.Pricing;
using RestaurantApi.Repositories;
using RestaurantApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Accepte les enums en chaine de caracteres dans le JSON (ex: "Category": "Starter").
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Enregistrement des dependances.
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<DishFactoryProvider>();
builder.Services.AddSingleton<PricingStrategyProvider>();

// Les trois services abonnes (pattern Observer).
builder.Services.AddSingleton<IOrderObserver, KitchenService>();
builder.Services.AddSingleton<IOrderObserver, DiningRoomService>();
builder.Services.AddSingleton<IOrderObserver, BillingService>();

builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Restaurant API is running. See /swagger for details.");

// Lister toutes les commandes.
app.MapGet("/api/orders", (OrderService service) =>
    Results.Ok(service.GetAllOrders().Select(OrderResponse.From)));

// Obtenir une commande par son id.
app.MapGet("/api/orders/{id}", (string id, OrderService service) =>
{
    var order = service.GetOrder(id);
    return order is null
        ? Results.NotFound()
        : Results.Ok(OrderResponse.From(order));
});

// Creer une commande (avec calcul de prix selon la politique choisie).
app.MapPost("/api/orders", (CreateOrderRequest request, OrderService service) =>
{
    var order = service.CreateOrder(request);
    if (order is null)
        return Results.BadRequest($"Unknown pricing strategy: '{request.PricingStrategy}'.");

    var response = OrderResponse.From(order);
    return Results.Created($"/api/orders/{order.Id}", response);
});

// Faire progresser la commande dans son workflow (pattern State).
app.MapPut("/api/orders/{id}/state", (string id, OrderService service) =>
{
    var order = service.AdvanceOrder(id);
    return order is null
        ? Results.NotFound()
        : Results.Ok(OrderResponse.From(order));
});

// Obtenir le menu complet (pattern Singleton).
app.MapGet("/api/menu", () =>
    Results.Ok(RestaurantConfiguration.Instance.Menu.Select(DishResponse.From)));

app.Run();
