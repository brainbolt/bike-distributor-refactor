using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class HtmlReceiptCreator : IReceiptCreator
    {
        public string GetReceipt(IOrder order)
        {
            var result = new StringBuilder($"<html><body><h1>Order Receipt for {order.Company}</h1>");
            if (order.GetLines().Any())
            {
                result.Append("<ul>");
                foreach (var line in order.GetLines())
                {
                    result.Append($"<li>{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {FormatCurrency(line.GetAmount())}</li>");
                }
                result.Append("</ul>");
            }
            result.Append($"<h3>Sub-Total: {FormatCurrency(order.GetSubtotalAmount())}</h3>");
            result.Append($"<h3>Tax: {FormatCurrency(order.GetTaxAmount())}</h3>");
            result.Append($"<h2>Total: {FormatCurrency(order.GetTotalAmount())}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }

        private object FormatCurrency(double amount)
        {
            return amount.ToString("C");
        }
    }
}
