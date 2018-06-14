using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachinesItemTest
    {
        VendingMachineItem item;

        [TestMethod]
        public void TestName()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Chips", item.Name);
        }

        [TestMethod]
        public void TestPrice()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual(1.50M, item.Price);
        }

        [TestMethod]
        public void TestType()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Chip", item.Type);
        }

        [TestMethod]
        public void TestMessage()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Crunch Crunch, Yum!", item.SetMessage("Chip"));
        }

        [TestMethod]
        public void TestMessage2()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Munch Munch, Yum!", item.SetMessage("Candy"));
        }

        [TestMethod]
        public void TestMessage3()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Glug Glug, Yum!", item.SetMessage("Drink"));
        }

        [TestMethod]
        public void TestMessage4()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual("Chew Chew, Yum!", item.SetMessage("Gum"));
        }

        [TestMethod]
        public void TestQuanity()
        {
            item = new VendingMachineItem("Chips", 1.50M, "Chip");
            Assert.AreEqual(5, item.Quantity);
        }
    }
}
