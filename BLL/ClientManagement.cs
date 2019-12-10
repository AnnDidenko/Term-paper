using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class ClientManagement
    {
        private List<Client> clients = new List<Client>();
        private DataContext<List<Client>> dataContext = new DataContext<List<Client>>();

        public List<Client> ShowClients
        {
            set
            {
                clients = value;
            }
            get
            {
                return clients;
            }
        }


        public void Add(Client client)
        {
            clients.Add(client);
        }

        public void Delete(int index)
        {
            clients.Remove(clients[index]);
        }

        public void ChangeData(int index, int field, string newData)
        {
            switch (field)
            {
                case 1: //Change Name
                    clients[index].ClientName = newData;
                    break;
                case 2: //Change Surname
                    clients[index].ClientSurname = newData;
                    break;
                case 3: //Change wanted type of realty
                    clients[index].RealtyType = newData;
                    break;
                case 4: //Change wanted cost of realty
                    clients[index].RealtyCost = Convert.ToInt32(newData);
                    break;
                case 5: //Change bank account
                    clients[index].BankingAccount = Convert.ToInt32(newData);
                    break;
            }
        }

        public List<Client> Sort(int typeOfSort)
        {
            switch (typeOfSort)
            {
                case 1: //Sorting by Name
                    clients = clients.OrderBy(i => i.ClientName).ToList();
                    break;
                case 2: //Sorting by Surname
                    clients = clients.OrderBy(i => i.ClientSurname).ToList();
                    break;
                case 3://Sorting by Banking Account
                    clients = clients.OrderBy(i => i.BankingAccount).ToList();
                    break;
            }
            return clients;
        }

        public string ShowClientInfo(int index)
        {
            return clients[index].ToString();
        }

        public void Serialize()
        {
            dataContext.Serialization(clients, 1);
        }
      
        public List<Client> Deserialize()
        {
            ShowClients = dataContext.Deserialization(1);
            return ShowClients;
        }

        public List<Realty> RealtyForWishList(List<Realty> realties, int index)
        {
            List<Realty> result = new List<Realty>();
            foreach(Realty realty in realties)
            {
                if(realty.RealtyType == clients[index].RealtyType)
                {
                    result.Add(realty);
                }
                else if(realty.RealtyCost < clients[index].RealtyCost+1000)
                {
                    result.Add(realty);
                }
                else if (realty.RealtyCost > clients[index].RealtyCost + 1000)
                {
                    result.Add(realty);
                }
            }
            clients[index].AllWishList = result;
            return result;
        }

        public bool Check(Realty realty, int index)
        {
            if(clients[index].WishList.Contains(realty))
            {
                return true;
            }
            return false;
        }
    }
}
