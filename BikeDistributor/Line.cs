namespace BikeDistributor
{
    public class Line
    {
        public Line(Bike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }

        public Bike Bike { get; private set; }
        public int Quantity { get; private set; }

        public double GetAmount()
        {
            double thisAmount = 0d;

            switch (Bike.Price)
            {
                case Bike.OneThousand:
                    if (Quantity >= 20)
                        thisAmount += Quantity * Bike.Price * .9d;
                    else
                        thisAmount += Quantity * Bike.Price;
                    break;
                case Bike.TwoThousand:
                    if (Quantity >= 10)
                        thisAmount += Quantity * Bike.Price * .8d;
                    else
                        thisAmount += Quantity * Bike.Price;
                    break;
                case Bike.FiveThousand:
                    if (Quantity >= 5)
                        thisAmount += Quantity * Bike.Price * .8d;
                    else
                        thisAmount += Quantity * Bike.Price;
                    break;
            }

            return thisAmount;
        }
    }
}
