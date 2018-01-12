using System;

namespace BikeDistributor
{
    public class ReceiptCreatorFactory
    {
        public IReceiptCreator MakeReceiptCreator(string receiptType)
        {
            IReceiptCreator creator;

            switch (receiptType)
            {
                case "default":
                    creator = new TextReceiptCreator();
                    break;
                case "text":
                    creator = new TextReceiptCreator();
                    break;
                case "html":
                    creator = new HtmlReceiptCreator();
                    break;
                default:
                    throw new ArgumentException($"invalid receipt type: {receiptType}");
            }

            return creator;
        }
    }
}
