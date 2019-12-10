using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class RealtyManagement
    {
        private List<Realty> realties = new List<Realty>();
        private DataContext<List<Realty>> dataContext = new DataContext<List<Realty>>();

        public List<Realty> ShowRealties
        {
            set
            {
                realties = value;
            }
            get
            {
                return realties;
            }
        }

        public void Add(Realty realty)
        {
            realties.Add(realty);
        }

        public void Delete(int index)
        {
            realties.Remove(realties[index]);
        }

        public void ChangeData(int index, int field, string newData)
        {
            switch (field)
            {
                case 1: //Change Type of realty
                    realties[index].RealtyType = newData;
                    break;
                case 2: //Change Cost of realty
                    realties[index].RealtyCost = Convert.ToInt32(newData);
                    break;
            }
        }

        public List<Realty> Sort(int typeOfSort)
        {
            switch (typeOfSort)
            {
                case 1: //Sorting by Type of realty
                    realties = realties.OrderBy(i => i.RealtyType).ToList();
                    break;
                case 2: //Sorting by Cost of realty
                    realties = realties.OrderBy(i => i.RealtyCost).ToList();
                    break;
            }
            return realties;
        }

        public string ShowRealtyInfo(int index)
        {
            return realties[index].ToString();
        }

        public void Serialize()
        {
            dataContext.Serialization(realties, 2);
        }
        public List<Realty> Deserialize()
        {
            ShowRealties = dataContext.Deserialization(2);
            return ShowRealties;
        }
    }
}
