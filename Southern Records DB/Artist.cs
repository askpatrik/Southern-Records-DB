using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southern_Records_DB
{
    internal class Artist
    {
        //Attributes
        public int id;
        public string name;
        public string nationality;


        //Static list
        public static List<Artist> artists = new List<Artist>();

        //Constructor
        public Artist(int id, string name, string nationality)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;

            //Add THIS objekt to list
            artists.Add(this);
        }
    }
}
