using System;

namespace BikeDistributor
{
    public partial class Bike
    {
        public const int OneThousand = 1000;
        public const int TwoThousand = 2000;
        public const int FiveThousand = 5000;

        private IBikePricer _pricer;

        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            SetPrice(price);
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Price { get { return GetPrice(); } set { SetPrice(value); } }

        private void SetPrice(int price)
        {
            switch (price)
            {
                case Bike.OneThousand:
                    _pricer = new OneThousandBikePricer();
                    break;
                case Bike.TwoThousand:
                    _pricer = new TwoThousandBikePricer();
                    break;
                case Bike.FiveThousand:
                    _pricer = new FiveThousandBikePricer();
                    break;
                default:
                    throw new ArgumentException("invalid price");
            }
        }

        private int GetPrice()
        {
            return _pricer.GetPrice();
        }

        public double GetAmount(int quantity)
        {
            return _pricer.GetAmount(quantity);

        }
    }
}
