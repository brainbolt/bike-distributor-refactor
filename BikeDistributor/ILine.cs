namespace BikeDistributor
{
    public interface ILine
    {
        IBike Bike { get; }
        int Quantity { get; }
        double GetAmount();
        void SetParentOrder(IOrder parentOrder);
    }
}
