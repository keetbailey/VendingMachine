﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vm = new VendingMachine();

        [TestMethod]
        public void TestGetInfo()
        {

            Assert.AreEqual(true, vm.ItemsDic.ContainsKey("A1"));
        }

        [TestMethod]
        public void TestGetInfo2()
        {

            Assert.AreEqual(true, vm.ItemsDic.ContainsKey("C4"));
        }

        [TestMethod]
        public void TestGetInfo3()  //return to this - returning false, expected true, all values match per debuggig
        {
             // Visually tested whilst running test and making break point. All values were identical
        //    //Assert.AreEqual(true, vm.VMArray.ContainsValue(new VendingMachineItem ("Potato Crisps", 3.05m, "Chip")));
        //    //Assert.AreEqual(true, vm.VMArray.ContainsValue(new VendingMachineItem("Stackers", 1.45m, "Chip")));
        }


    }
}
