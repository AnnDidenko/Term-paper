using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    class ClientMenu
    {
        private ClientManagement clientManagement = new ClientManagement();
        RegularExpressions regularExpressions = new RegularExpressions();

        public ClientManagement listOfClients
        {
            get
            {
                return clientManagement;
            }
        }

        public void ClientManagement()
        {
            int k = 1;
            while (k != 0)
            {
                Console.WriteLine("Choose the operation:");
                Console.WriteLine("1 - Add a client");
                Console.WriteLine("2 - Delete a client");
                Console.WriteLine("3 - Change data");
                Console.WriteLine("4 - Show client's data");
                Console.WriteLine("5 - Show all list of clients");
                Console.WriteLine("6 - Wrire in file");
                Console.WriteLine("7 - Read from file");
                k = Convert.ToInt32(Console.ReadLine());
                try
                {
                    regularExpressions.CheckChoise(Convert.ToString(k));
                }
                catch
                {
                    Console.WriteLine("Incorrect input!!!");
                    Console.WriteLine("Try again");
                }
                if (k != 0)
                {
                    switch (k)
                    {
                        case 1:
                            AddClient();
                            break;
                        case 2:
                            DeleteClient();
                            break;
                        case 3:
                            ChangeClientData();
                            break;
                        case 4:
                            ShowClientData();
                            break;
                        case 5:
                            ShowAllClients();
                            break;
                        case 6:
                            Serialize();
                            break;
                        case 7:
                            Deserialize();
                            break;
                    }
                }
            }
        }

        public void AddClient()
        {
            try
            {
                Console.WriteLine("Write name of client:");
                string name = Console.ReadLine();
                Console.WriteLine("Write surname of client:");
                string surname = Console.ReadLine();
                Console.WriteLine("Write what type of realty you need:");
                string typeOfRealty = Console.ReadLine();
                Console.WriteLine("Write cost of realty you need:");
                int costOfRealty = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write client's bank account:");
                int bankAccount = Convert.ToInt32(Console.ReadLine());
                Client client = new Client(name, surname, typeOfRealty, costOfRealty, bankAccount);
                regularExpressions.CheckClients(client);
                clientManagement.Add(client);
            }
            catch
            {
                Console.WriteLine("Incorrect input!!!");
                Console.WriteLine("Try again");
            }
        }

        public void DeleteClient()
        {
            Console.WriteLine("Write client's index:");
            int index = Convert.ToInt32(Console.ReadLine());
            try
            {
                clientManagement.Delete(index);
            }
            catch
            {
                Console.WriteLine("Index out of range!");
                Console.WriteLine("You can't delete client");
            }
        }

        public void ChangeClientData()
        {
            try
            {
                Console.WriteLine("Write client's index:");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write 1 if you want to change name, 2 - surname, 3 - wanted type of realty, 4 - wanted cost of realty, 5 - bank account:");
                int field = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write new data:");
                string newData = Console.ReadLine();
                clientManagement.ChangeData(index, field, newData);
            }
            catch
            {
                Console.WriteLine("Incorrect input!!!");
                Console.WriteLine("Try again");
            }
        }

        public void ShowClientData()
        {
            try
            {
                Console.WriteLine("Write client's index:");
                int index = Convert.ToInt32(Console.ReadLine());
                if (clientManagement.ShowClientInfo(index) == null)
                {
                    Console.WriteLine("Index out of range!");
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine(clientManagement.ShowClientInfo(index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAllClients()
        {
            List<Client> result = new List<Client>();
            Console.WriteLine("Choose type of sorting: 1 - by name of client, 2 - by surname of client, 3 - by banking account");
            int type = Convert.ToInt32(Console.ReadLine());
            result = clientManagement.Sort(type);
            foreach (Client client in result)
            {
                Console.WriteLine(client.ToString());
            }
        }

        public void Serialize()
        {
            clientManagement.Serialize();
        }

        public void Deserialize()
        {
            clientManagement.Deserialize();
        }

        public void CreateWishList(List<Realty> realties)
        {
            try
            {
                List<Realty> result = new List<Realty>();
                List<Realty> allRealties = new List<Realty>();
                Console.WriteLine("Write client's index:");
                int index = Convert.ToInt32(Console.ReadLine());
                allRealties = clientManagement.RealtyForWishList(realties, index);
                foreach (Realty realty in allRealties)
                {
                    Console.WriteLine(realty.ToString());
                    Console.WriteLine("Do you want to accept the proposition?");
                    Console.WriteLine("1 - Yes");
                    Console.WriteLine("2 - No");
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k == 1)
                    {
                        result.Add(realty);
                    }
                }
                clientManagement.ShowClients[index].WishList = result;
                Console.WriteLine("Do you want to see all list of propositions?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                int z = Convert.ToInt32(Console.ReadLine());
                if (z == 1)
                {
                    foreach (Realty realty in result)
                    {
                        Console.WriteLine(realty.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CheckWishList(List<Realty> realties)
        {
            try
            {
                Console.WriteLine("Write client's index:");
                int indexOfClient = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write realty's index:");
                int indexOfRealty = Convert.ToInt32(Console.ReadLine());
                if (clientManagement.ShowClients[indexOfClient].WishList == null)
                {
                    Console.WriteLine("List of propositions is emplty!!!");
                    Console.WriteLine("You should fill it!");
                    CreateWishList(realties);
                }
                bool check = clientManagement.Check(realties[indexOfRealty], indexOfClient);
                if (check)
                {
                    Console.WriteLine("List of propositions contains this object");
                }
                else Console.WriteLine("List of propositions doesn't contain this object");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RealtyOffersManagement(List<Realty> realties)
        {
            Console.WriteLine("Choose the operation:");
            Console.WriteLine("1 - See list of propositions");
            Console.WriteLine("2 - Check if list of propositions contains realty with this parameter");
            int z = Convert.ToInt32(Console.ReadLine());
            if (z != 0)
            {
                switch (z)
                {
                    case 1:
                        CreateWishList(realties);
                        break;
                    case 2:
                        CheckWishList(realties);
                        break;
                }

            }
        }


    }
}
