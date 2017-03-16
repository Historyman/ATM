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
            ATM.ATM testDrawer = new ATM.ATM();

            //act
            testDrawer.Withdraw(withdrawlAmount);

            //assert
            int actual = testDrawer.Total;
            Assert.AreEqual(expected, testDrawer.Total);
        }

        [TestMethod]
        public void Drawer_Will_Not_Overdraft()
        {
            //arrange
            int tooMuchMoney = 2000000;
            ATM.ATM testDrawer = new ATM.ATM();

            //act
            testDrawer.Withdraw(tooMuchMoney);

            //assert
            Assert.IsTrue(testDrawer.Total > 0);
        }

        [TestMethod]
        public void Withdrawl_Will_Use_Smaller_Bills_If_Needed()
        {
            //arrange
            ATM.ATM testDrawer = new ATM.ATM();

            //act
            for (int i = 0; i < 6; i++)
            {
                testDrawer.Withdraw(240);
            }

            //assert for a few denominations
            int expected100BillCount = 0;
            int actual100BillCount = testDrawer.GetDenominationCount("$100");
            Assert.AreEqual(expected100BillCount, actual100BillCount, "$100 Doesnt Match");

            int expected50BillCount = 6;
            int actual50BillCount = testDrawer.GetDenominationCount("$50");
            Assert.AreEqual(expected50BillCount, actual50BillCount, "$50 Doesnt Match");

            int expected10BillCount = 6;
            int actual10BillCount = testDrawer.GetDenominationCount("$10");
            Assert.AreEqual(expected10BillCount, actual10BillCount, "$10 Doesnt Match");
        }
    }
}


