using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soins
{
    class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private List<Prestation> listePrestations;

        public Dossier(string nom, string prenom, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
        }

        public Dossier(string nom, string prenom, DateTime dateNaissance, Prestation prestation) : this(nom, prenom, dateNaissance)
        {
            AjoutePrestation(prestation);
        }

        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> listePrestations) : this(nom, prenom, dateNaissance)
        {
            this.listePrestations = listePrestations;
        }

        public void AjoutePrestation(Prestation p)
        {
            listePrestations.Add(p);
        }
        
        public int GetNbPrestationsExternes()
        {
           int cpt = 0;
            foreach (Prestation prestation in listePrestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    cpt++;
                }
            }
            return cpt;
        }   

        public int GetNbPrestations()
        {
            return listePrestations.Count;
        }

        public int GetNbJoursSoinsV1()
        {
            int nb = this.listePrestations.Count;
            for (int i = 0; i < this.listePrestations.Count - 1; i++)
            {
                for (int j = i + 1; j < this.listePrestations.Count; j++)
                {
                    if (Prestation.CompareTo(this.listePrestations[i], this.listePrestations[j]) == 0)
                    {
                        nb--;
                    }
                }
            }
            return nb;
        }
        public int GetNbJoursSoinsV2()
        {

            List<DateTime> dates = new List<DateTime>();
           
            foreach (Prestation p in listePrestations)
            {
                if (!dates.Contains(p.DateHeureSoin.Date))
                {
                    dates.Add(p.DateHeureSoin.Date);
                }
            }
            return dates.Count;
        }
        public int GetNbJoursSoinsV3()
        {
           List<Prestation> listeTriee = listePrestations.OrderBy(p => p.DateHeureSoin.Date).ToList();

            DateTime comparatif = listeTriee[0].DateHeureSoin.Date;
            int cpt = 1;
            foreach (Prestation p in listeTriee)
            {
                if (comparatif != p.DateHeureSoin.Date)
                {
                    cpt++;
                    comparatif = p.DateHeureSoin.Date;
                }
            }
            return cpt;
        }
        public string Nom { get => nom; }
        public string Prenom { get => prenom;  }
        public DateTime DateNaissance { get => dateNaissance;  }
    }
}
