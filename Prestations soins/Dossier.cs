using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private List<Prestation> listePrestations;
        private DateTime dateCreation;

        public Dossier(string nom, string prenom, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            if (dateNaissance.Date.CompareTo(DateTime.Now.Date) <=0)
            {
                this.dateNaissance = dateNaissance;
            }
            else
            {
                throw new SoinsException("La date de naissance ne peut pas être supérieure à la dta du jour");
            }
            listePrestations = new List<Prestation>();
            //dateCreation = DateTime.Now;
            dateCreation = new DateTime(1990, 12, 25);
        }
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation) : this(nom,prenom,dateNaissance)
        {
            if (dateCreation.Date.CompareTo(DateTime.Now.Date)<=0)
            {
                this.dateCreation = dateCreation;
            }
            else
            {
                throw new SoinsException("Date de création non valide");
            }
        }

        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation, Prestation prestation) : this(nom, prenom, dateNaissance)
        {
            if (dateCreation.Date.CompareTo(DateTime.Now.Date) <= 0)
            {
                this.dateCreation = dateCreation;
            }
            else
            {
                throw new SoinsException("Date de création non valide");
            }
            AjoutePrestation(prestation);
        }

        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation, List<Prestation> listePrestations) : this(nom, prenom, dateNaissance)
        {
            if (dateCreation.Date.CompareTo(DateTime.Now.Date) <= 0)
            {
                this.dateCreation = dateCreation;
            }
            else
            {
                throw new SoinsException("Date de création non valide");
            }
            this.listePrestations = listePrestations;
        }

        public void AjoutePrestation(Prestation p)
        {
            if (p.DateHeureSoin.Date.CompareTo(this.DateCreation.Date)>= 0)
            {
                listePrestations.Add(p);
            }
            else
            {
                throw new SoinsException("La date de prestation doit être postérieure à la date de création du dossier");
            }
            
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

        public static bool IsDateTime(string txtDate)
        {
            DateTime format;
            return DateTime.TryParse(txtDate, out format);
        }
        public override string ToString()
        {
            Console.WriteLine("-----Début Dossier--------------");
            string s = "\n Nom : " + this.Nom + " Prenom : " + this.Prenom + " Date de naissance : " + this.DateNaissance;

            foreach (Prestation prestation in listePrestations)
            {
                s += prestation;
            }
            return s;
        }
        public string Nom { get => nom; }
        public string Prenom { get => prenom;  }
        public DateTime DateNaissance { get => dateNaissance;  }
        public DateTime DateCreation { get => dateCreation; }
    }
}
