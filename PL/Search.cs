using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    class Search
    {
        private MySearch search = new MySearch();

        public void MySearch(ClientMenu clientMenu, RealtyMenu realtyMenu)
        {
            Console.WriteLine("Choose the operation:");
            Console.WriteLine("1 - Search clients");
            Console.WriteLine("2 - Search realties");
            Console.WriteLine("3 - Search all data");
            Console.WriteLine("4 - Extended search");
            int k = Convert.ToInt32(Console.ReadLine());
            switch (k)
            {
                case 1:
                    SearchForClients(clientMenu);
                    break;
                case 2:
                    SearchForRealties(realtyMenu);
                    break;
                case 3:
                    SearchAllData(clientMenu, realtyMenu);
                    break;
                case 4:
                    ExtendedSearch(clientMenu, realtyMenu);
                    break;
            }
        }

        public void SearchForClients(ClientMenu clientMenu)
        {
            List<Client> result = new List<Client>();
            Console.WriteLine("Write 1 if you want to search by wanted type of realty, 2 - by wanted cost of realty, 3 - by name, 4 - by surname, 5 - by bank account:");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write searched data: ");
            string data = Console.ReadLine();
            result = search.searchClients(clientMenu.listOfClients.ShowClients, type, data);
            foreach (Client client in result)
            {
                Console.WriteLine(client.ToString());
            }
        }

        public void SearchForRealties(RealtyMenu realtyMenu)
        {
            List<Realty> result = new List<Realty>();
            Console.WriteLine("Write 1 if you want to search by wanted type of realty, 2 - by wanted cost of realty:");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write searched data: ");
            string data = Console.ReadLine();
            result = search.searchRealties(realtyMenu.listOfRealties.ShowRealties, type, data);
            foreach (Realty realty in result)
            {
                Console.WriteLine(realty.ToString());
            }
        }

        public void SearchAllData(ClientMenu clientMenu, RealtyMenu realtyMenu)
        {
            List<Client> clients = new List<Client>();
            List<Realty> realties = new List<Realty>();
            Console.WriteLine("Write 1 if you want to search by wanted type of realty, 2 - by wanted cost of realty:");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write searched data: ");
            string data = Console.ReadLine();
            clients = search.searchClients(clientMenu.listOfClients.ShowClients, type, data);
            foreach (Client client in clients)
            {
                Console.WriteLine(client.ToString());
            }
            realties = search.searchRealties(realtyMenu.listOfRealties.ShowRealties, type, data);
            foreach (Realty realty in realties)
            {
                Console.WriteLine(realty.ToString());
            }
        }

        public void ExtendedSearch(ClientMenu clientMenu, RealtyMenu realtyMenu)
        {
            List<Client> clients = new List<Client>();
            List<Realty> realties = new List<Realty>();
            Console.WriteLine("Write number of searched fields:");
            int number = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine("Write 1 if you want to search by wanted type of realty, 2 - by wanted cost of realty, 3 - by name, 4 - by surname, 5 - by bank account:");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write searched data: ");
                string data = Console.ReadLine();
                clients.AddRange(search.searchClients(clientMenu.listOfClients.ShowClients, type, data));
                realties.AddRange(search.searchRealties(realtyMenu.listOfRealties.ShowRealties, type, data));
            }
            foreach (Client client in clients)
            {
                Console.WriteLine(client.ToString());
            }
            foreach (Realty realty in realties)
            {
                Console.WriteLine(realty.ToString());
            }
        }
    }
}
