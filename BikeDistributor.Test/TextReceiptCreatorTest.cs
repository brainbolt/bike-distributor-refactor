using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeDistributor.Test
{
    [TestClass]
    public class TextReceiptCreatorTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        [TestMethod]
        public void TextReceiptCreator_GetReceipt_OneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 1));
            var receiptCreator = new TextReceiptCreator();
            Assert.AreEqual(ResultStatementOneDefy, receiptCreator.GetReceipt(order));
        }

        private const string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50";

        [TestMethod]
        public void TextReceiptCreator_GetReceipt_OneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 1));
            var receiptCreator = new TextReceiptCreator();
            Assert.AreEqual(ResultStatementOneElite, receiptCreator.GetReceipt(order));
        }

        private const string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00";

        [TestMethod]
        public void TextReceiptCreator_GetReceipt_OneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 1));
            var receiptCreator = new TextReceiptCreator();
            Assert.AreEqual(ResultStatementOneDuraAce, receiptCreator.GetReceipt(order));
        }

        private const string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50";
    }
}
