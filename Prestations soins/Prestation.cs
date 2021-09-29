using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;


        public Prestation(string libelle, DateTime dateHeureSoin)
        {
            this.Libelle = libelle;
            //this.dateHeureSoin.Date.CompareTo(DateTime.Now.Date) <= 0
            if (DateTime.Compare(DateTime.Now.Date,dateHeureSoin.Date) >= 0)
            {
                this.dateHeureSoin = dateHeureSoin;
            }
            else
            {
                throw new SoinsException("La date de prestation ne peut pas être après le jour actuel");
            }
        }
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant): this(libelle, dateHeureSoin)
        {
            this.intervenant = intervenant;
        }

        public static int CompareTo(Prestation a, Prestation b)
        {
            return DateTime.Compare(a.DateHeureSoin.Date, b.DateHeureSoin.Date);
        }

        public override string ToString()
        {
            return " \n\tLibelle " + this.libelle + " " + this.dateHeureSoin + "- Intervenant : " + this.intervenant;

        }
        public string Libelle { get => libelle; set => libelle = value; }
        public DateTime DateHeureSoin { get => dateHeureSoin; set => dateHeureSoin = value; }
        public Intervenant Intervenant { get => intervenant; set => intervenant = value; }

    }
}
