using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPELourd
{
    class Equipement

    {
        private int Id;
        private string nom;
        private bool disponible;
        private int idCategorie; // Ajout du champ idCategorie


        public Equipement( int id , string nom ,bool disponible, int idCategorie)
        {
            this.Id = id;
            this.nom = nom;
            this.disponible = disponible;
            this.idCategorie = idCategorie; 




           }

        public int GetId()
        {
            return Id;
        }


        public void SetId(int id)
        {
            this.Id = id;
        }

        public string GetNom()
        {
            return nom;
        }


        public void SetNom( string nom)
        {
            this.nom = nom;
        }

        public bool GetDisponible()
        {
            return disponible;
        }

        public void SetDisponible( bool disponible)
        {
            this.disponible = disponible;
        }

        public int GetIdCategorie()
        {
            return idCategorie;
        }

        public void SetIdCategorie(int idCategorie)
        {
            this.idCategorie = idCategorie;
        }

        public override string ToString()
        {
            return $"Equipement [Id={Id}, Nom={nom}, Disponible={disponible}] , IdCategorie={idCategorie}]";
        }
    }
}
