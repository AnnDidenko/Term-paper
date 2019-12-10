using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;

namespace Tests_for_BLL
{
    [TestClass]
    public class ClientManagementTest
    {
        private ClientManagement clientManagement = new ClientManagement();
        List<Realty> realties = new List<Realty>();

        private Client client1 = new Client("Eva", "Petrova", "3 room", 20000, 34267);
        private Client client2 = new Client("Liza", "Ivanova", "1 room", 10000, 54362);
        private Client client3 = new Client("Alina", "Palamarchuck", "1 room", 15000, 45786);
        private Realty realty1 = new Realty("3 room", 10000);
        private Realty realty2 = new Realty("1 room", 22000);
        private Realty realty3 = new Realty("5 room", 50000);

        public void CreateObjects()
        { 
            clientManagement.Add(client1);
            clientManagement.Add(client2);
            clientManagement.Add(client3);
        }

        public void CreateRealties()
        {
            realties.Add(realty1);
            realties.Add(realty2);
            realties.Add(realty3);
        }

        [TestMethod]
        public void ChangeData_should_changeName()
        {
            string newName;
            string nameOfClient;
            CreateObjects();
            newName = "Kate";
            clientManagement.ChangeData(0, 1, newName);
            nameOfClient = clientManagement.ShowClients[0].ClientName;
            Assert.AreEqual(newName, nameOfClient);
        }

        [TestMethod]
        public void ChangeData_should_changeSurname()
        {
            string newSurname;
            string surnameOfClient;
            CreateObjects();
            newSurname = "Chorna";
            clientManagement.ChangeData(1, 2, newSurname);
            surnameOfClient = clientManagement.ShowClients[1].ClientSurname;
            Assert.AreEqual(newSurname, surnameOfClient);
        }

        [TestMethod]
        public void ChangeData_should_changeTypeOfRealty()
        {
            string newType;
            string typeOfClient;
            CreateObjects();
            newType = "4 room";
            clientManagement.ChangeData(2, 3, newType);
            typeOfClient = clientManagement.ShowClients[2].RealtyType;
            Assert.AreEqual(newType, typeOfClient);
        }

        [TestMethod]
        public void ChangeData_should_changeCostOfRealty()
        {
            string newCost;
            string costOfClient;
            CreateObjects();
            newCost = "21000";
            clientManagement.ChangeData(0, 4, newCost);
            costOfClient = Convert.ToString(clientManagement.ShowClients[0].RealtyCost);
            Assert.AreEqual(newCost, costOfClient);
        }

        [TestMethod]
        public void ChangeData_should_changeBankAccount()
        {
            string newBankAccount;
            string bankAccountOfClient;
            CreateObjects();
            newBankAccount = "56565";
            clientManagement.ChangeData(0, 5, newBankAccount);
            bankAccountOfClient = Convert.ToString(clientManagement.ShowClients[0].BankingAccount);
            Assert.AreEqual(newBankAccount, bankAccountOfClient);
        }

        [TestMethod]
        public void Sort_shouldReturn_SortedbyNameList()
        {
            ClientManagement sortedList = new ClientManagement();
            CreateObjects();
            sortedList.ShowClients = clientManagement.Sort(1);
            Assert.IsTrue(sortedList.ShowClients[0] == client3 && sortedList.ShowClients[1] == client1 && sortedList.ShowClients[2] == client2);
        }
         
        [TestMethod]
        public void Sort_shouldReturn_SortedbySurnameList()
        {
            ClientManagement sortedList = new ClientManagement();
            CreateObjects();
            sortedList.ShowClients = clientManagement.Sort(2);
            Assert.IsTrue(sortedList.ShowClients[0] == client2 && sortedList.ShowClients[1] == client3 && sortedList.ShowClients[2] == client1);
        }

        [TestMethod]
        public void Sort_shouldReturn_SortedbyBankAccount()
        {
            ClientManagement sortedList = new ClientManagement();
            CreateObjects();
            sortedList.ShowClients = clientManagement.Sort(3);
            Assert.IsTrue(sortedList.ShowClients[0] == client1 && sortedList.ShowClients[1] == client3 && sortedList.ShowClients[2] == client2);
        }

        [TestMethod]
        public void ShowClientInfo_shouldReturn_Client()
        {
            string showClient;
            string client;
            CreateObjects();
            showClient = clientManagement.ShowClientInfo(0);
            client = client1.ToString();
            Assert.AreEqual(client, showClient);
        }

        [TestMethod]
        public void RealtyForWishList_shouldReturn_PropositionsForClient()
        {
            List<Realty> myRealty = new List<Realty>();
            CreateObjects();
            CreateRealties();
            myRealty = clientManagement.RealtyForWishList(realties, 0);
            Assert.AreEqual(myRealty[0], realty1);
        }
    }
}
