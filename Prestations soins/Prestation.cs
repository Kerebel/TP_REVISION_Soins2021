using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soins
{
    class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;
        private IntervenantExterne interExt;


        public Prestation(string libelle, DateTime dateHeureSoin)
        {
            this.Libelle = libelle;
            this.DateHeureSoin = dateHeureSoin;
        }
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant): this(libelle, dateHeureSoin)
        {
            this.intervenant = intervenant;
        }
        public Prestation(string libelle, DateTime dateHeureSoin, IntervenantExterne interExt) : this (libelle, dateHeureSoin)
        {
            this.interExt = interExt;
        }

        public static int CompareTo(Prestation a, Prestation b)
        {
            return DateTime.Compare(a.DateHeureSoin.Date, b.DateHeureSoin.Date);
        }

        public string Libelle { get => libelle; set => libelle = value; }
        public DateTime DateHeureSoin { get => dateHeureSoin; set => dateHeureSoin = value; }
        public Intervenant Intervenant { get => intervenant; set => intervenant = value; }

        public IntervenantExterne InterExt { get => interExt; set => interExt = value; }

    }
}
