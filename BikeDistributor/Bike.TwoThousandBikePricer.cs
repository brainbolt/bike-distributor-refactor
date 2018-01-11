namespace BikeDistributor
{
    public partial class Bike
    {
        class TwoThousandBikePricer : IBikePricer
        {
            public double GetAmount(int quantity)
            {
                double amount = quantity * GetPrice();

                if (quantity >= 10)
                {
                    amount *= .8d;
                }

                return amount;
            }

            public int GetPrice()
            {
                return Bike.TwoThousand;
            }
        }
    }
}
