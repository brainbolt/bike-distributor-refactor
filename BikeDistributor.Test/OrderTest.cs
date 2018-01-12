using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BikeDistributor.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Order_GetReceipt_ShouldThrow_ArgumentNullException_WhenPassedNullArg()
        {
            var order = new Order("");
            order.GetReceipt(null);
        }

        [TestMethod]
        public void Order_GetSubtotalAmount_ShouldReturn_Zero_WhenOrderHasNoLines()
        {
            var order = new Order("");
            Assert.AreEqual(0d, order.GetSubtotalAmount());
        }

        [TestMethod]
        public void Order_GetSubtotalAmount_ShouldReturn_Twenty_FromOrderWithTwoTenLines()
        {
            var order = new Order("");
            order.AddLine(new MockLineA(10));
            order.AddLine(new MockLineA(10));

            Assert.AreEqual(20d, order.GetSubtotalAmount());
        }

        [TestMethod]
        public void Order_GetTaxAmount_ShouldReturn_Zero_WhenOrderHasNoLines()
        {
            var order = new Order("");
            Assert.AreEqual(0d, order.GetTaxAmount());
        }

        [TestMethod]
        public void Order_GetTaxAmount_ShouldReturn_SeventyTwoFifity_WhenOrderHasOneThousandLine()
        {
            var order = new Order("");
            order.AddLine(new MockLineA(1000));
            Assert.AreEqual(72.5d, order.GetTaxAmount());
        }

        [TestMethod]
        public void Order_GetTotalAmount_ShouldReturn_Zero_WhenOrderHasNoLines()
        {
            var order = new Order("");
            Assert.AreEqual(0d, order.GetTotalAmount());
        }

        [TestMethod]
        public void Order_GetTotalAmount_ShouldReturn_OneThousandSeventyTwoFifty_WhenOrderHasOneThousandLine()
        {
            var order = new Order("");
            order.AddLine(new MockLineA(1000));
            Assert.AreEqual(1072.5d, order.GetTotalAmount());
        }

        [TestMethod]
        public void Order_GetLines_ShouldReturn_IReadOnlyCollectionOfILineType()
        {
            var order = new Order("");
            Assert.IsInstanceOfType(order.GetLines(), typeof(IReadOnlyCollection<ILine>));
        }

        [TestMethod]
        public void Order_GetLines_ShouldReturn_EmptyCollection_WhenOrderHasNoLines()
        {
            var order = new Order("");
            Assert.AreEqual(0, order.GetLines().Count);
        }

        [TestMethod]
        public void Order_GetLines_ShouldReturn_CollectionWithCountOfThree_WhenOrderHasThreeLines()
        {
            var order = new Order("");
            order.AddLine(new MockLineA(0));
            order.AddLine(new MockLineA(0));
            order.AddLine(new MockLineA(0));
            Assert.AreEqual(3, order.GetLines().Count);
        }

        [TestMethod]
        public void Order_AddLine_ShouldIncrement_GetLines_Count_ByOne()
        {
            var order = new Order("");

            Assert.AreEqual(0, order.GetLines().Count);

            order.AddLine(new MockLineA(0));

            Assert.AreEqual(1, order.GetLines().Count);
        }

        #region Mock Objects

        class MockLineA : ILine
        {
            private double _amount;
            public MockLineA(double amount)
            {
                _amount = amount; 
            }
            public IBike Bike => throw new NotImplementedException();

            public int Quantity => throw new NotImplementedException();

            public double GetAmount()
            {
                return _amount;
            }

            public void SetParentOrder(IOrder parentOrder)
            {
                
            }
        }

        #endregion
    }
}
