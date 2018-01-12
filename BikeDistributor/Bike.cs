using System;

namespace BikeDistributor
{
    public partial class Bike : IBike
    {
        public const int OneThousand = 1000;
        public const int TwoThousand = 2000;
        public const int FiveThousand = 5000;

        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Price { get; private set; }

        public double GetAmount(int quantity, IBikePricer bikePricer)
        {
            return bikePricer.GetAmount(this, quantity);
        }
    }
}
