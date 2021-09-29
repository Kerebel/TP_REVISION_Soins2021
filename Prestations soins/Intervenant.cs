using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class Intervenant
    {
        private string nom;
        private string prenom;
        private List<Prestation> listePrestations = new List<Prestation>();

        public Intervenant(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public void AjoutePrestation(string libelle, DateTime dateHeureSoin)
        {
            listePrestations.Add(new Prestation(libelle, dateHeureSoin));
        }

        public int GetNbPrestations()
        {
            return listePrestations.Count;
        }

        public override string ToString()
        {
            return this.nom + "- " + this.prenom;
        }
        public string Nom { get => nom;  }
        public string Prenom { get => prenom;  }
    }
}
