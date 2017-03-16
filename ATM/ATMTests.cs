using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM;

namespace UnitTests
{
    [TestClass]
    public class ATMTests
    {
        [TestMethod]
        public void Withdrawl_Updates_Drawer()
        {
            //arrange
            int withdrawlAmount = 217;
            int expected = 1643;
            CashDrawer testDrawer = new CashDrawer();

            //act
            testDrawer.Withdraw(withdrawlAmount);

            //assert
            int actual = testDrawer.Total;
            Assert.AreEqual(expected, testDrawer.Total);
        }
    }

    [TestClass]
    public void Drawer_Will_Not_Overdraft
    {

    }
}
