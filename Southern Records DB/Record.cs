using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southern_Records_DB
{
    internal class Record
    {
        //Attributes
        public int id;
        public string title;
        public int year;

        //Static list
        public static List<Record> records = new List<Record>();

        //Constructor
        public Record(int id, string title, int year)
        {
            this.id = id;
            this.title = title;
            this.year = year;

            //Add THIS objekt to list
            records.Add(this);
        }

    }
}