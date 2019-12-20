using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Aliments
    {
        [PrimaryKey, AutoIncrement]
        public int alim_id { get; set; }

        public string alim_name { get; set; }

        public string alim_imageUrl { get; set; }

        [ForeignKey(typeof(Categorie))]
        public int alim_categorie_id { get; set; }
    }
}
