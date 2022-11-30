using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southern_Records_DB
{
    internal class Customer
    {
 
            public int id;
            public string firstname;
            public string lastname;
         
            //Static list
            public static List<Customer> customers = new List<Customer>();

            //Constructor
            public Customer (int id, string firstname, string lastname)
            {
                this.id = id;
                this.firstname = firstname;
                this.lastname = lastname;

                //Add THIS objekt to list
                customers.Add(this);
            }
        }
    }
