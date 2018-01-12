﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class HtmlReceiptCreatorTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        [TestMethod]
        public void HtmlReceiptCreator_GetReceipt_OneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            var receiptCreator = new HtmlReceiptCreator();
            Assert.AreEqual(HtmlResultStatementOneDefy, receiptCreator.GetReceipt(order));
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptCreator_GetReceipt_OneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            var receiptCreator = new HtmlReceiptCreator();
            Assert.AreEqual(HtmlResultStatementOneElite, receiptCreator.GetReceipt(order));
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";

        [TestMethod]
        public void HtmlReceiptCreator_GetReceipt_OneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            var receiptCreator = new HtmlReceiptCreator();
            Assert.AreEqual(HtmlResultStatementOneDuraAce, receiptCreator.GetReceipt(order));
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";
    }
}
