namespace BikeDistributor
{
    public class Line : ILine
    {
        private IOrder _parentOrder;
        public Line(IBike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }

        public IBike Bike { get; private set; }
        public int Quantity { get; private set; }

        public void SetParentOrder(IOrder parentOrder)
        {
            _parentOrder = parentOrder;
        }

        public double GetAmount()
        {
            return Bike.GetAmount(Quantity, _parentOrder.GetPricer());
        }
    }
}
