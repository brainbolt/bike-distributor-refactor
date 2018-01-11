using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class Order
    {
        private const double TaxRate = .0725d;
        private readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }

        private double GetSubtotalAmount()
        {
            double subtotal = 0d;

            foreach (var line in _lines)
            {
                subtotal += line.GetAmount();
            }

            return subtotal;
        }

        private double GetTaxAmount()
        {
            return GetSubtotalAmount() * TaxRate;
        }

        private double GetTotalAmount()
        {
            return GetSubtotalAmount() + GetTaxAmount();
        }

        private string FormatCurrency(double amount)
        {
            return amount.ToString("C");
        }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            var result = new StringBuilder($"Order Receipt for {Company}{Environment.NewLine}");
            foreach (var line in _lines)
            {
                result.AppendLine($"\t{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {FormatCurrency(line.GetAmount())}");
            }
            result.AppendLine($"Sub-Total: {FormatCurrency(GetSubtotalAmount())}");
            result.AppendLine($"Tax: {FormatCurrency(GetTaxAmount())}");
            result.Append($"Total: {FormatCurrency(GetTotalAmount())}");
            return result.ToString();
        }

        public string HtmlReceipt()
        {
            var result = new StringBuilder($"<html><body><h1>Order Receipt for {Company}</h1>");
            if (_lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _lines)
                {
                    result.Append($"<li>{line.Quantity} x {line.Bike.Brand} {line.Bike.Model} = {FormatCurrency(line.GetAmount())}</li>");
                }
                result.Append("</ul>");
            }
            result.Append($"<h3>Sub-Total: {FormatCurrency(GetSubtotalAmount())}</h3>");
            result.Append($"<h3>Tax: {FormatCurrency(GetTaxAmount())}</h3>");
            result.Append($"<h2>Total: {FormatCurrency(GetTotalAmount())}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}
