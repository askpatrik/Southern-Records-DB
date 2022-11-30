using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southern_Records_DB
{
    internal class Seller
    { 
    
        //Attributes
        public int id;
        public string name;
  
        //Static list
        public static List<Seller> sellers = new List<Seller>();

        //Constructor
        public Seller(int id, string name)
        {
            this.id = id;
            this.name = name;
           

            //Add THIS objekt to list
            sellers.Add(this);
        }
    }
}