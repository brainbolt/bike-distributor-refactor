namespace BikeDistributor
{
    public interface IReceiptCreator
    {
        string GetReceipt(IOrder order);
    }
}
