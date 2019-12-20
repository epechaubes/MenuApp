using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Categorie
    {
        [PrimaryKey]
        public int categorie_id { get; set; }

        public string categorie_nom { get; set; }

        [OneToMany]
        public List<Aliments> categorie_aliments { get; set; }
    }
}
