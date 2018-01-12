using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BikeDistributor
{
    public class Order : IOrder
    {
        private const double TaxRate = .0725d;
        private readonly IList<ILine> _lines = new List<ILine>();
        private IBikePricer _bikePricer;

        public Order(string company, IBikePricer bikePricer = null)
        {
            if (bikePricer == null) _bikePricer = new BikePricerFactory().MakeBikePricer("default");
            Company = company;
        }

        public string Company { get; private set; }

        public void AddLine(ILine line)
        {
            line.SetParentOrder(this);
            _lines.Add(line);
        }

        public string GetReceipt(IReceiptCreator receiptCreator)
        {
            if (receiptCreator == null) throw new ArgumentNullException(nameof(receiptCreator));
            return receiptCreator.GetReceipt(this);
        }

        public double GetSubtotalAmount()
        {
            double subtotal = 0d;

            foreach (var line in _lines)
            {
                subtotal += line.GetAmount();
            }

            return subtotal;
        }

        public double GetTaxAmount()
        {
            return GetSubtotalAmount() * TaxRate;
        }

        public double GetTotalAmount()
        {
            return GetSubtotalAmount() + GetTaxAmount();
        }

        public IReadOnlyCollection<ILine> GetLines()
        {
            return new ReadOnlyCollection<ILine>(_lines);
        }

        public IBikePricer GetPricer()
        {
            return _bikePricer;
        }

        public void SetBikePricer(IBikePricer bikePricer)
        {
            _bikePricer = bikePricer;
        }
    }
}
