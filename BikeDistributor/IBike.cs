namespace BikeDistributor
{
    public interface IBike
    {
        string Brand { get; }
        string Model { get; }
        int Price { get; }
        double GetAmount(int quantity);
    }
}
