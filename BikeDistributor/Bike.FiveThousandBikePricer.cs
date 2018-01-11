namespace BikeDistributor
{
    public partial class Bike
    {
        class FiveThousandBikePricer : IBikePricer
        {
            public double GetAmount(int quantity)
            {
                double amount = quantity * GetPrice();

                if (quantity >= 5)
                {
                    amount *= .8d;
                }

                return amount;
            }

            public int GetPrice()
            {
                return Bike.FiveThousand;
            }
        }
    }
}
