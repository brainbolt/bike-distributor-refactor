namespace BikeDistributor
{
    public partial class Bike
    {
        interface IBikePricer
        {
            int GetPrice();
            double GetAmount(int quantity);
        }
    }
}
