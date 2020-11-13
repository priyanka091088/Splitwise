using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitwiseApp.DomainModels.Models;
using SplitwiseApp.Repository.Settlements;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.Modules.Settlements
{
    [TestClass]
    public class SettlementRepositoryTest
    {
        SettlementRepository s = new SettlementRepository();

        [TestMethod]
        public void AddingSettlementTest()
        {

            Settlement addSettlement = new Settlement();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => s.AddSettlementDetails(addSettlement));

        }

        [TestMethod]

        public void UpdatingSettlementTest()
        {

            Settlement updateSettlement = new Settlement();
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => s.UpdateSettlementDetails(updateSettlement));

        }
        [TestMethod]

        public void GetSettlementDetailsTest()
        {
            //Assert.ThrowsExceptionAsync<NotImplementedException>(() => s.GetSettlementDetails("1"));

        }
    }
}
