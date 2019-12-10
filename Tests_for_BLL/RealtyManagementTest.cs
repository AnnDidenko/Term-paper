using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_for_BLL
{
    [TestClass]
    public class RealtyManagementTest
    {
        private RealtyManagement realtyManagement = new RealtyManagement();

        private Realty realty1 = new Realty("3 room", 10000);
        private Realty realty2 = new Realty("1 room", 22000);
        private Realty realty3 = new Realty("5 room", 15000);

        public void CreateRealties()
        {
            realtyManagement.Add(realty1);
            realtyManagement.Add(realty2);
            realtyManagement.Add(realty3);
        }

        [TestMethod]
        public void ChangeData_should_changeTypeOfRealty()
        {
            string newType;
            string typeOfRealty;
            CreateRealties();
            newType = "4 room";
            realtyManagement.ChangeData(2, 1, newType);
            typeOfRealty = realtyManagement.ShowRealties[2].RealtyType;
            Assert.AreEqual(newType, typeOfRealty);
        }

        [TestMethod]
        public void ChangeData_should_changeCostOfRealty()
        {
            string newCost;
            string costOfRealty;
            CreateRealties();
            newCost = "11000";
            realtyManagement.ChangeData(0, 2, newCost);
            costOfRealty = Convert.ToString(realtyManagement.ShowRealties[0].RealtyCost);
            Assert.AreEqual(newCost, costOfRealty);
        }

        [TestMethod]
        public void Sort_shouldReturn_SortedbyTypeList()
        {
            RealtyManagement sortedList = new RealtyManagement();
            CreateRealties();
            sortedList.ShowRealties = realtyManagement.Sort(1);
            Assert.IsTrue(sortedList.ShowRealties[0] == realty2 && sortedList.ShowRealties[1] == realty1 && sortedList.ShowRealties[2] == realty3);
        }

        [TestMethod]
        public void Sort_shouldReturn_SortedbyCostList()
        {
            RealtyManagement sortedList = new RealtyManagement();
            CreateRealties();
            sortedList.ShowRealties = realtyManagement.Sort(2);
            Assert.IsTrue(sortedList.ShowRealties[0] == realty1 && sortedList.ShowRealties[1] == realty3 && sortedList.ShowRealties[2] == realty2);
        }

        [TestMethod]
        public void ShowRealtyInfo_shouldReturn_Realty()
        {
            string showRealty;
            string realty;
            CreateRealties();
            showRealty = realtyManagement.ShowRealtyInfo(0);
            realty = realty1.ToString();
            Assert.AreEqual(realty, showRealty);
        }
    }
}
