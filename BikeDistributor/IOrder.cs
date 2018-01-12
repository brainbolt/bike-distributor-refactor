using System.Collections.Generic;

namespace BikeDistributor
{
    public interface IOrder
    {
        string Company { get; }
        string GetReceipt(IReceiptCreator receiptCreator);
        double GetTaxAmount();
        double GetTotalAmount();
        double GetSubtotalAmount();
        IReadOnlyCollection<ILine> GetLines();
        void AddLine(ILine line);
    }
}
