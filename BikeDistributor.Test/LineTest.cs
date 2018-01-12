using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void Line_GetAmount_ShouldCall_Bike_GetAmount()
        {
            var bike = new MockBikeA();
            var line = new Line(bike, 0);

            Assert.IsFalse(bike.GetHasBeenCalled());

            line.GetAmount();

            Assert.IsTrue(bike.GetHasBeenCalled());
        }

        [TestMethod]
        public void Line_GetAmount_ShouldPassQuantityTo_Bike_GetAmount()
        {
            int quantity = 34;
            var bike = new MockBikeB();
            var line = new Line(bike, quantity);
            line.GetAmount();

            Assert.AreEqual(quantity, bike.GetQuantity());
        }

        #region Mock Objects

        class MockBikeA : IBike
        {
            bool hasBeenCalled;
            public string Brand => throw new NotImplementedException();

            public string Model => throw new NotImplementedException();

            public int Price => throw new NotImplementedException();

            public double GetAmount(int quantity)
            {
                hasBeenCalled = true;
                return 0d;
            }

            public bool GetHasBeenCalled()
            {
                return hasBeenCalled;
            }
        }

        class MockBikeB : IBike
        {
            int _quantity;
            public string Brand => throw new NotImplementedException();

            public string Model => throw new NotImplementedException();

            public int Price => throw new NotImplementedException();

            public double GetAmount(int quantity)
            {
                _quantity = quantity;
                return 0d;
            }

            public int GetQuantity()
            {
                return _quantity;
            }
        }

        #endregion
    }
}
