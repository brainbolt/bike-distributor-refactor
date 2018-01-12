using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class QuantityBikePricerTest
    {
        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_Zero_WhenPassed_ZeroQuantity()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(1000);
            Assert.AreEqual(0d, pricer.GetAmount(bike, 0));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_OneThousand_WhenPassed_OneOneThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(1000);
            Assert.AreEqual(1000d, pricer.GetAmount(bike, 1));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_NineteenThousand_WhenPassed_NineteenOneThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(1000);
            Assert.AreEqual(19000d, pricer.GetAmount(bike, 19));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_EighteenThousand_WhenPassed_TwentyOneThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(1000);
            Assert.AreEqual(18000d, pricer.GetAmount(bike, 20));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_TwoThousand_WhenPassed_OneTwoThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(2000);
            Assert.AreEqual(2000d, pricer.GetAmount(bike, 1));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_EighteenThousand_WhenPassed_NineTwoThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(2000);
            Assert.AreEqual(18000d, pricer.GetAmount(bike, 9));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_SixteenThousand_WhenPassed_TenTwoThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(2000);
            Assert.AreEqual(16000d, pricer.GetAmount(bike, 10));
        }


        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_FiveThousand_WhenPassed_OneFiveThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(5000);
            Assert.AreEqual(5000d, pricer.GetAmount(bike, 1));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_TwentyThousand_WhenPassed_FourFiveThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(5000);
            Assert.AreEqual(20000d, pricer.GetAmount(bike, 4));
        }

        [TestMethod]
        public void QuantityBikePricer_GetAmount_ShouldReturn_TwentyThousand_WhenPassed_FiveFiveThousandBike()
        {
            var pricer = new QuantityBikePricer();
            var bike = new MockBikeA(5000);
            Assert.AreEqual(20000d, pricer.GetAmount(bike, 5));
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
