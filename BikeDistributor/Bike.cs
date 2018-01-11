namespace BikeDistributor
{
    public class Bike
    {
        public const int OneThousand = 1000;
        public const int TwoThousand = 2000;
        public const int FiveThousand = 5000;
    
        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Price { get; set; }

        public double GetAmount(int quantity)
        {
            double thisAmount = 0d;

            switch (Price)
            {
                case Bike.OneThousand:
                    if (quantity >= 20)
                        thisAmount += quantity * Price * .9d;
                    else
                        thisAmount += quantity * Price;
                    break;
                case Bike.TwoThousand:
                    if (quantity >= 10)
                        thisAmount += quantity * Price * .8d;
                    else
                        thisAmount += quantity * Price;
                    break;
                case Bike.FiveThousand:
                    if (quantity >= 5)
                        thisAmount += quantity * Price * .8d;
                    else
                        thisAmount += quantity * Price;
                    break;
            }

            return thisAmount;

        }
    }
}
