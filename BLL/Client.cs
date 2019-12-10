using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Client
    {
        private List<Realty> WishList1 = new List<Realty>();
        private List<Realty> WishList2 = new List<Realty>();

        public List<Realty> AllWishList
        {
            set
            {
                WishList1 = value;
            }
            get
            {
                return WishList1;
            }
        }

        public List<Realty> WishList
        {
            set
            {
                WishList2 = value;
            }
            get
            {
                return WishList2;
            }
        }

        public string RealtyType { get; set; }
       
        public string ClientName { get; set; }

        public string ClientSurname { get; set; }

        public int RealtyCost { get; set; }

        public int BankingAccount { get; set; }

        public Client(string name, string surname, string typeOfRealty, int costOfRealty, int bankAccount)
        {
            ClientName = name;
            ClientSurname = surname;
            RealtyType = typeOfRealty;
            RealtyCost = costOfRealty;
            BankingAccount = bankAccount;
        }

        public override string ToString()
        {
            return $"Name: {ClientName} Surname: {ClientSurname} Bank account: {BankingAccount} Wanted type of realty: {RealtyType} Wanted cost of realty: {RealtyCost}";
        }
    }
}
