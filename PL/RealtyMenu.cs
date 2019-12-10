using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    class RealtyMenu
    {
        private RealtyManagement realtyManagement = new RealtyManagement();
        RegularExpressions regularExpressions = new RegularExpressions();

        public RealtyManagement listOfRealties
        {
            get
            {
                return realtyManagement;
            }
        }

        public void RealtyDataManagement()
        {
            int k = 1;
            while (k != 0)
            {
                Console.WriteLine("Choose the operation:");
                Console.WriteLine("1 - Add a realty");
                Console.WriteLine("2 - Delete a realty");
                Console.WriteLine("3 - Change data");
                Console.WriteLine("4 - Show realty's data");
                Console.WriteLine("5 - Show all list of realties");
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
                            AddRealty();
                            break;
                        case 2:
                            DeleteRealty();
                            break;
                        case 3:
                            ChangeData();
                            break;
                        case 4:
                            ShowRealtyData();
                            break;
                        case 5:
                            ShowAllRealties();
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

        public void AddRealty()
        {
            try
            {

                Console.WriteLine("Write type of realty:");
                string typeOfRealty = Console.ReadLine();
                Console.WriteLine("Write cost of realty:");
                int costOfRealty = Convert.ToInt32(Console.ReadLine());
                Realty realty = new Realty(typeOfRealty, costOfRealty);
                regularExpressions.CheckRealty(realty);
                realtyManagement.Add(realty);
            }
            catch
            {
                Console.WriteLine("Incorrect input!!!");
                Console.WriteLine("Try again");
            }
        }

        public void DeleteRealty()
        {
            Console.WriteLine("Write realty's index:");
            int index = Convert.ToInt32(Console.ReadLine());
            try
            {
                realtyManagement.Delete(index);
            }
            catch
            {
                Console.WriteLine("Index out of range!");
                Console.WriteLine("You can't delete client");
            }
        }

        public void ChangeData()
        {
            try
            {
                Console.WriteLine("Write realty's index:");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write 1 if you want to change type of realty, 2 - cost:");
                int field = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write new data:");
                string newData = Console.ReadLine();
                realtyManagement.ChangeData(index, field, newData);
            }
            catch
            {
                Console.WriteLine("Incorrect input!!!");
                Console.WriteLine("Try again");
            }
        }

        public void ShowRealtyData()
        {
            try
            {
                Console.WriteLine("Write realty's index:");
                int index = Convert.ToInt32(Console.ReadLine());
                if(realtyManagement.ShowRealtyInfo(index) == null)
                {
                    Console.WriteLine("Index out of range!");
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine(realtyManagement.ShowRealtyInfo(index));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAllRealties()
        {
            List<Realty> result = new List<Realty>();
            Console.WriteLine("Choose type of sorting: 1 - by type of realty, 2 - by cost of realty");
            int type = Convert.ToInt32(Console.ReadLine());
            result = realtyManagement.Sort(type);
            foreach (Realty realty in result)
            {
                Console.WriteLine(realty.ToString());
            }
        }

        public void Serialize()
        {
            realtyManagement.Serialize();
        }

        public void Deserialize()
        {
            realtyManagement.Deserialize();
        }
    }
}
