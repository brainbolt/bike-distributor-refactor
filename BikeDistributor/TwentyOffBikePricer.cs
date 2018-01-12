namespace BikeDistributor
{
    public class TwentyOffBikePricer : IBikePricer
    {
        public double GetAmount(IBike bike, int quantity)
        {
            return bike.Price * quantity * .8d;
        }
    }
}
