using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class BikePricerFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BikePricerFactory_MakeBikePricer_ShouldThrow_ArgumentException_WhenPassedEmptyString()
        {
            var factory = new BikePricerFactory().MakeBikePricer("");
        }

        [TestMethod]
        public void ReceiptCreatorFactory_GetReceiptCreator_ShouldReturn_TextReceiptCreatorType_WhenPassed_default()
        {
            var pricer = new BikePricerFactory().MakeBikePricer("default");
            Assert.IsInstanceOfType(pricer, typeof(QuantityBikePricer));
        }

        [TestMethod]
        public void ReceiptCreatorFactory_GetReceiptCreator_ShouldReturn_TextReceiptCreatorType_WhenPassed_text()
        {
            var pricer = new BikePricerFactory().MakeBikePricer("quantity");
            Assert.IsInstanceOfType(pricer, typeof(QuantityBikePricer));
        }

        [TestMethod]
        public void ReceiptCreatorFactory_GetReceiptCreator_ShouldReturn_HtmlReceiptCreatorType_WhenPassed_html()
        {
            var pricer = new BikePricerFactory().MakeBikePricer("20off");
            Assert.IsInstanceOfType(pricer, typeof(TwentyOffBikePricer));
        }
    }
}
