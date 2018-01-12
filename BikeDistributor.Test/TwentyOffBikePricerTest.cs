using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class TwentyOffBikePricerTest
    {
        [TestMethod]
        public void TwentyOffBikePricer_GetAmount_ShouldReturn_Zero_WhenPassed_ZeroQuantity()
        {
            var pricer = new TwentyOffBikePricer();
            var bike = new MockBikeA(1000);

            Assert.AreEqual(0d, pricer.GetAmount(bike, 0));
        }

        [TestMethod]
        public void TwentyOffBikePricer_GetAmount_ShouldReturn_EightHundred_WhenPassed_One_OneThousandBike()
        {
            var pricer = new TwentyOffBikePricer();
            var bike = new MockBikeA(1000);

            Assert.AreEqual(800d, pricer.GetAmount(bike, 1));
        }

        #region Mock Objects

        class MockBikeA : IBike
        {
            public MockBikeA(int price)
            {
                Price = price;
            }
            public string Brand => throw new NotImplementedException();

            public string Model => throw new NotImplementedException();

            public int Price { get; private set; }

            public double GetAmount(int quantity, IBikePricer bikePricer)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
