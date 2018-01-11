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
            return Bike.GetAmount(Quantity);
        }
    }
}
