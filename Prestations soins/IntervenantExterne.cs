using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private int tel;

        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, int tel) : base(nom, prenom)
        {
            this.Specialite = specialite;
            this.Adresse = adresse;
            this.Tel = tel;
        }

        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.specialite + " " + this.adresse + "- " + this.tel;
        }
        public string Specialite { get => specialite; set => specialite = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public int Tel { get => tel; set => tel = value; }
    }
}
