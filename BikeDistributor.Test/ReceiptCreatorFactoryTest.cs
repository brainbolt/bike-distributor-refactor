using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class ReceiptCreatorFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReceiptCreatorFactory_MakeReceiptCreator_ShouldThrow_ArgumentException_WhenPassedEmptyString()
        {
            var factory = new ReceiptCreatorFactory().MakeReceiptCreator("");
        }

        [TestMethod]
        public void ReceiptCreatorFactory_MakeReceiptCreator_ShouldReturn_TextReceiptCreatorType_WhenPassed_default()
        {
            var creator = new ReceiptCreatorFactory().MakeReceiptCreator("default");
            Assert.IsInstanceOfType(creator, typeof(TextReceiptCreator));
        }

        [TestMethod]
        public void ReceiptCreatorFactory_MakeReceiptCreator_ShouldReturn_TextReceiptCreatorType_WhenPassed_text()
        {
            var creator = new ReceiptCreatorFactory().MakeReceiptCreator("text");
            Assert.IsInstanceOfType(creator, typeof(TextReceiptCreator));
        }

        [TestMethod]
        public void ReceiptCreatorFactory_MakeReceiptCreator_ShouldReturn_HtmlReceiptCreatorType_WhenPassed_html()
        {
            var creator = new ReceiptCreatorFactory().MakeReceiptCreator("html");
            Assert.IsInstanceOfType(creator, typeof(HtmlReceiptCreator));
        }
    }
}
