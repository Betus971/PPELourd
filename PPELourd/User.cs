using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace PPELourd
{
    class User
    {
        private static User utilisateurConnecte;

        public static User GetutilisateurConnecte()
        {
            return utilisateurConnecte;
        }

        public static void SetUtilisateurConnecte(User value)
        {
            utilisateurConnecte = value;
        }

        public int Id { get; set; }
        private string nom;
        private string prenom;
        private string pseudo;
        private string mdp;


        public User (int Id ,string nom, string prenom, string pseudo, string mdp)

        {
            this.Id = Id;
            this.nom = nom;
            this.prenom = prenom;
            this.pseudo = pseudo;
            this.mdp = mdp;

        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }


        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }



        // Getter et Setter pour Pseudo
        public string GetPseudo()
        {
            return pseudo;
        }

        public void SetPseudo(string value)
        {
            pseudo = value;
        }

        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }

































    }
}
