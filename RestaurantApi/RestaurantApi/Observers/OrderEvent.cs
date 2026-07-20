namespace RestaurantApi.Observers
{
    // Les evenements du cycle de vie d'une commande diffuses aux observers.
    public enum OrderEvent
    {
        Created,
        PreparationStarted,
        Ready,
        Served,
        Paid
    }
}
