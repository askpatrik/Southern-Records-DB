using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southern_Records_DB
{
    internal class Genre
    {
        //Attributes
        public int id;
        public string genre;


        //Static list
        public static List<Genre> genres = new List<Genre>();

        //Constructor
        public Genre(int id, string genre)
        {
            this.id = id;
            this.genre = genre;

            //Add THIS objekt to list
            genres.Add(this);
        }


    }
}