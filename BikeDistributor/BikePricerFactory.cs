using System;

namespace BikeDistributor
{
    public class BikePricerFactory
    {
        public IBikePricer MakeBikePricer(string bikePricerType)
        {
            IBikePricer pricer;

            switch (bikePricerType)
            {
                case "default":
                    pricer = new QuantityBikePricer();
                    break;
                case "quantity":
                    pricer = new QuantityBikePricer();
                    break;
                case "20off":
                    pricer = new TwentyOffBikePricer();
                    break;
                default:
                    throw new ArgumentException($"invalid type: {bikePricerType}");
            }

            return pricer;
        }
    }
}
