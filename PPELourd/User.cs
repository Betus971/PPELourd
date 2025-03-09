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
        public static User UtilisateurConnecte { get; set; }

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



        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }


        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }

































    }
}
