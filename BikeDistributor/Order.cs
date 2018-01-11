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

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", Company, Environment.NewLine));
            foreach (var line in _lines)
            {
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, line.GetAmount().ToString("C")));
            }
            result.AppendLine(string.Format("Sub-Total: {0}", GetSubtotalAmount().ToString("C")));
            result.AppendLine(string.Format("Tax: {0}", GetTaxAmount().ToString("C")));
            result.Append(string.Format("Total: {0}", GetTotalAmount().ToString("C")));
            return result.ToString();
        }

        public string HtmlReceipt()
        {
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Company));
            if (_lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _lines)
                {
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, line.GetAmount().ToString("C")));
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", GetSubtotalAmount().ToString("C")));
            result.Append(string.Format("<h3>Tax: {0}</h3>", GetTaxAmount().ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", GetTotalAmount().ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}
