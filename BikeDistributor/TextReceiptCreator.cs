using System;
using System.Text;

namespace BikeDistributor
{
    public class TextReceiptCreator : IReceiptCreator
    {
        public string GetReceipt(IOrder order)
        {
            var result = new StringBuilder($"Order Receipt for {order.Company}{Environment.NewLine}");
            foreach (var line in order.GetLines())
            {
                result.AppendLine($"\t{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {FormatCurrency(line.GetAmount())}");
            }
            result.AppendLine($"Sub-Total: {FormatCurrency(order.GetSubtotalAmount())}");
            result.AppendLine($"Tax: {FormatCurrency(order.GetTaxAmount())}");
            result.Append($"Total: {FormatCurrency(order.GetTotalAmount())}");
            return result.ToString();
        }

        private object FormatCurrency(double amount)
        {
            return amount.ToString("C");
        }
    }
}
