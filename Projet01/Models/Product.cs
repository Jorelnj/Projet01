using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet01.Models
{
    class Product
    {
        public void Deserialize(string value)
        {
            string[] tab = value?.Split('|');
            if(tab != null && tab.Length >= NUMBER_OF_PROPERTIES)
            {
                Reference = tab[0];
                Name = tab[1];
                Price = double.Parse(tab[2]);
                Tax = float.Parse(tab[3]);
            }
        }
    }
}
