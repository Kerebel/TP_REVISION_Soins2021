using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Début dossier------------");

            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            IntervenantExterne intervenant2 = new IntervenantExterne("Durant", "Annie", "Cardiologue", "Marseille",0202020202);
            IntervenantExterne intervenant3 = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon",030303030);
            Intervenant intervenant4 = new Intervenant("Maurin", "Joelle");
            Intervenant intervenant5 = new Intervenant("Blanchard", "Michel");
            Intervenant intervenant6 = new Intervenant("Tournier", "Helene");

            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            Prestation prestation2 = new Prestation("P1", Convert.ToDateTime("01/09/2015 12:00:00"), intervenant2);
            Prestation prestation3 = new Prestation("P2", Convert.ToDateTime("08/09/2015 12:00:00"), intervenant3);
            Prestation prestation4 = new Prestation("P4", Convert.ToDateTime("20/09/2015 12:00:00"), intervenant4);
            Prestation prestation5 = new Prestation("P6", Convert.ToDateTime("08/09/2015 09:00:00"), intervenant5);
            Prestation prestation6 = new Prestation("P5", Convert.ToDateTime("10/09/2015 06:00:00"), intervenant6);

            List<Prestation> listePrestations = new List<Prestation>();
            listePrestations.Add(prestation1);
            listePrestations.Add(prestation2);
            listePrestations.Add(prestation3);
            listePrestations.Add(prestation4);
            listePrestations.Add(prestation5);
            listePrestations.Add(prestation6);
            Dossier doss1 = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3), listePrestations);

            

            Console.WriteLine("Nom : " + doss1.Nom + "Prenom : " + doss1.Prenom + "Date de naissance : " + doss1.DateNaissance);
            Console.WriteLine("\t Libelle " + prestation1.Libelle + "- " + prestation1.DateHeureSoin + "- Intervenant : " + intervenant1.Nom + "- " + intervenant1.Prenom);
            Console.WriteLine("\t Libelle " + prestation2.Libelle + "- " + prestation2.DateHeureSoin + "- Intervenant : " + intervenant2.Nom + "- " + intervenant2.Prenom +"Spécialité : " + intervenant2.Specialite + "" + intervenant2.Adresse + "- " + intervenant2.Tel);
            Console.WriteLine("\t Libelle " + prestation3.Libelle + "- " + prestation3.DateHeureSoin + "- Intervenant : " + intervenant3.Nom + "- " + intervenant3.Prenom + "Spécialité : " + intervenant3.Specialite + "" + intervenant3.Adresse + "- " + intervenant3.Tel);
            Console.WriteLine("\t Libelle " + prestation4.Libelle + "- " + prestation4.DateHeureSoin + "- Intervenant : " + intervenant4.Nom + "- " + intervenant4.Prenom);
            Console.WriteLine("\t Libelle " + prestation5.Libelle + "- " + prestation5.DateHeureSoin + "- Intervenant : " + intervenant5.Nom + "- " + intervenant5.Prenom);
            Console.WriteLine("\t Libelle " + prestation6.Libelle + "- " + prestation6.DateHeureSoin + "- Intervenant : " + intervenant6.Nom + "- " + intervenant6.Prenom);
            Console.WriteLine("-------------Fin dossier --------------");
            Console.WriteLine("Nombre de jours de soins V1 :" + doss1.GetNbJoursSoinsV1());
            Console.WriteLine("Nombre de jours de soins V2 :" + doss1.GetNbJoursSoinsV2());
            Console.WriteLine("Nombre de jours de soins V3 :" + doss1.GetNbJoursSoinsV3());
            Console.WriteLine("Nombre de soins externes : " + doss1.GetNbPrestationsExternes());
            
            Console.ReadKey();
        }
    }
}
