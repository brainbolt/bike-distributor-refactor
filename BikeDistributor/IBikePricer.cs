namespace BikeDistributor
{
    public interface IBikePricer
    {
        double GetAmount(IBike bike, int quantity);
    }
}
