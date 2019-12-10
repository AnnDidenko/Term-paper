using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MySearch
    {
        public List<Client> searchClients(List<Client> clients, int type, string data)
        {
            List<Client> searchedClients = new List<Client>();
            foreach(Client client in clients)
            {
                switch(type)
                {
                    case 1://Search by type of realty
                        if (client.RealtyType == data)
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case 2://Search by cost of realty
                        if (client.RealtyCost == Convert.ToInt32(data))
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case 3://Search by name
                        if (client.ClientName == data)
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case 4://Search by surname
                        if (client.ClientSurname == data)
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case 5://Search by bank account
                        if (client.BankingAccount == Convert.ToInt32(data))
                        {
                            searchedClients.Add(client);
                        }
                        break;
                }
            }
            return searchedClients;
        }

        public List<Realty> searchRealties(List<Realty> realties, int type, string data)
        {
            List<Realty> searchedRealty = new List<Realty>();
            foreach (Realty realty in realties)
            {
                switch (type)
                {
                    case 1://Search by type
                        if (realty.RealtyType == data)
                        {
                            searchedRealty.Add(realty);
                        }
                        break;
                    case 2://Search by cost
                        if (realty.RealtyCost == Convert.ToInt32(data))
                        {
                            searchedRealty.Add(realty);
                        }
                        break;
                }
            }
            return searchedRealty;
        }

    }
}
