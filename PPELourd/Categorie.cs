using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace PPELourd
{
    class Categorie
    {
        public int Id;
        private string nom;


        public Categorie(int id, string nom)
        {
            this.Id = id;
            this.nom = nom;
        }
        
        
        public int GetId()
        {
            return Id;
        }
        
        public void SetId(int id )
        {
            this.Id = id;
        }
        
        
        
        
        public string GetNom()
        {
            return nom;
        }
        
        public void SetNom(string nom)
        {
            this.nom = nom;
        }
        
        
        public override string ToString()
        {
            return $"Categorie [id={Id},Nom={nom}]";
        }
    }
}
