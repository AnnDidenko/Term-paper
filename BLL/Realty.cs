using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Realty
    {

        public string RealtyType { get; set; }

        public int RealtyCost { get; set; }

        public Realty(string typeOfRealty, int costOfRealty)
        {
            RealtyType = typeOfRealty;
            RealtyCost = costOfRealty;
        }

        public override string ToString()
        {
            return $"Type of realty: {RealtyType} Cost of realty: {RealtyCost}";
        }
    }
}
