using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class Menu
    {
        ClientMenu clientMenu = new ClientMenu();
        RealtyMenu realtyMenu = new RealtyMenu();
        Search search = new Search();
        public void MainMenu()
        {
            int k = 1;
            while (k != 0)
            {
                Console.WriteLine("Choose the operation:");
                Console.WriteLine("1 - Client management");
                Console.WriteLine("2 - Realty data management");
                Console.WriteLine("3 - Realty offers management");
                Console.WriteLine("4 - Search");
                k = Convert.ToInt32(Console.ReadLine());
                if (k != 0)
                {
                    switch (k)
                    {
                        case 1:
                            clientMenu.ClientManagement();
                            break;
                        case 2:
                            realtyMenu.RealtyDataManagement();
                            break;
                        case 3:
                            clientMenu.RealtyOffersManagement(realtyMenu.listOfRealties.ShowRealties);
                            break;
                        case 4:
                            search.MySearch(clientMenu, realtyMenu);
                            break;
                    }
                }
            }
        }

    }
}
