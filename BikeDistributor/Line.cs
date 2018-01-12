namespace BikeDistributor
{
    public class Line : ILine
    {
        public Line(IBike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }

        public IBike Bike { get; private set; }
        public int Quantity { get; private set; }

        public double GetAmount()
        {
            return Bike.GetAmount(Quantity);
        }
    }
}
