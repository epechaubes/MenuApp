using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stub
{
    public class StubAliments : IAlimentsManager
    {
        public List<Aliments> GetAllAliments()
        {
            return aliments;
        }

        public List<Aliments> GetAlimentsByCategory(int cate)
        {
            var alims = aliments.FindAll(t => t.alim_categorie_id == cate);
            return alims;
        }

        List<Categorie> categories = new List<Categorie>()
        {
            new Categorie { categorie_id=0, categorie_nom="Entrée" },
            new Categorie { categorie_id=1, categorie_nom="Viande" },
            new Categorie { categorie_id=2, categorie_nom="Accompagnement" },
            new Categorie { categorie_id=3, categorie_nom="Dessert" }
        };

        List<Aliments> aliments = new List<Aliments>()
        {
            new Aliments { alim_name="Salade auvergnate", alim_imageUrl="saladeAuvergnate.jpg", alim_categorie_id=0},
            new Aliments { alim_name="Maïs", alim_imageUrl="mais.jpg", alim_categorie_id=0},
            new Aliments { alim_name="Oeuf mimosa", alim_imageUrl="oeufMimosa.jpg", alim_categorie_id=0},
            new Aliments { alim_name="Salade avocat crevette", alim_imageUrl="saladeAvocatCrevette.jpg", alim_categorie_id=0},
            new Aliments { alim_name="Cabillaud au four", alim_imageUrl="cabillaud.jpg", alim_categorie_id=1},
            new Aliments { alim_name="Rôti de porc", alim_imageUrl="rotiPorc.jpg", alim_categorie_id=1},
            new Aliments { alim_name="Steack haché", alim_imageUrl="steackHache.jpg", alim_categorie_id=1},
            new Aliments { alim_name="Camembert au four", alim_imageUrl="camembert.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Coquillettes", alim_imageUrl="coquillettes.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Frites", alim_imageUrl="frites.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Riz", alim_imageUrl="riz.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Flageolets", alim_imageUrl="flageolets.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Haricots verts", alim_imageUrl="haricots.jpg", alim_categorie_id=2},
            new Aliments { alim_name="Kloug", alim_imageUrl="kloug.jpg", alim_categorie_id=3},
            new Aliments { alim_name="Doubitchous", alim_imageUrl="doubitchou.jpg", alim_categorie_id=3},
            new Aliments { alim_name="Banane", alim_imageUrl="banane.jpg", alim_categorie_id=3},
            new Aliments { alim_name="Pomme", alim_imageUrl="pomme.jpg", alim_categorie_id=3},
            new Aliments { alim_name="Crème brûlée", alim_imageUrl="cremeBrule.jpg", alim_categorie_id=3},
            new Aliments { alim_name="Salade de fruits", alim_imageUrl="saladeFruit.jpg", alim_categorie_id=3}
        };
    }
}
