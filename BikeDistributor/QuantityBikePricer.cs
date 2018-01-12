namespace BikeDistributor
{
    public class QuantityBikePricer : IBikePricer
    {
        public double GetAmount(IBike bike, int quantity)
        {
            double amount = quantity * bike.Price;

            if (bike.Price == Bike.OneThousand && quantity >= 20)
            {
                amount *= .9d;
            }
            else if (bike.Price == Bike.TwoThousand && quantity >= 10)
            {
                amount *= .8d;
            }
            else if (bike.Price == Bike.FiveThousand && quantity >= 5)
            {
                amount *= .8d;
            }

            return amount;
        }
    }
}
