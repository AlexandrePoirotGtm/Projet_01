using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Destination
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Continent { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        


        public Destination()
        {
            Nom = "paris";
            Description = "blabla";
            Continent = "europe";
            Pays = "france";
            Region = "Ile-de-France";
        }
    }




}
