using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BLL;

namespace PL
{
    class RegularExpressions
    {
        string name = "[A-Z]{1}[a-z]+";
        string costOfRealty = "[0-9]+";
        string bankAccount = "[0-9]+";
        string choiseOfOperations = "[0-7]{1}";

        public void CheckClients(Client client)
        {
            if(!FindMatchesForClients(client))
            {
                throw new Exception();
            }
        }

        public void CheckRealty(Realty realty)
        {
            if (!FindMatchesForRealty(realty))
            {
                throw new Exception();
            }
        }

        public void CheckChoise(string i)
        {
            bool check = false;
            if(Regex.IsMatch(i, choiseOfOperations))
            {
                check = true;
            }
            if(!check)
            {
                throw new Exception();
            }
        }

        public bool FindMatchesForClients(Client client)
        {
            if (Regex.IsMatch(client.ClientName, name))
            {
                if (Regex.IsMatch(client.ClientSurname, name))
                {
                    if (Regex.IsMatch(client.RealtyCost.ToString(), costOfRealty))
                    {
                        if (Regex.IsMatch(client.BankingAccount.ToString(), bankAccount))
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        public bool FindMatchesForRealty(Realty realty)
        {
            if (Regex.IsMatch(realty.RealtyCost.ToString(), costOfRealty))
            {
                return true;
            }
            return false;
        }
    }
}
