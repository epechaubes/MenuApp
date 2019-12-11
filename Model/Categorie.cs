using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Categorie
    {
        [PrimaryKey]
        public int cate_id { get; set; }

        public string cate_nom { get; set; }
    }
}
