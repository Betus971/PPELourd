using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPELourd
{
    class Reservation
    {
        public int Id { get; set; }
        public Equipement Equipement { get; set; }
        public string Utilisateur { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime? DateRetour { get; set; } // Optionnel : pour gérer le retour de l'équipement



        public Reservation(int id, Equipement equipement, string utilisateur, DateTime dateReservation)
        {
            Id = id;
            Equipement = equipement;
            Utilisateur = utilisateur;
            DateReservation = dateReservation;
            DateRetour = null;
        }

        public override string ToString()
        {
            return $"Réservation [Id={Id}, Equipement={Equipement.GetNom}, Utilisateur={Utilisateur}, Date={DateReservation}]";
        }
    }
}
