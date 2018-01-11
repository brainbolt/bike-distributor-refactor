namespace BikeDistributor
{
    public partial class Bike
    {
        class OneThousandBikePricer : IBikePricer
        {
            public double GetAmount(int quantity)
            {
                double amount = quantity * GetPrice();

                if (quantity >= 20)
                {
                    amount *= .9d;
                }

                return amount;
            }

            public int GetPrice()
            {
                return Bike.OneThousand;
            }
        }
    }
}
