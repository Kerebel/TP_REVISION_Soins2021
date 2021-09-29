using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soins2021
{
    static class Traitement
    {

        public static void TestDossier()
        {

            List<Prestation> listePrestations = new List<Prestation>();
            Dossier undossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3), new DateTime(1980, 12, 3), listePrestations);


            Prestation p1 = new Prestation("P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));

            Prestation p2 = new Prestation("P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", 0202020202));

            Prestation p3 = new Prestation("P2", new DateTime(2015, 9, 8, 12, 0, 0), new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", 0303030303));

            Prestation p4 = new Prestation("P4", new DateTime(2015, 9, 20, 12, 0, 0), new Intervenant("Maurin", "Joëlle"));

            Prestation p5 = new Prestation("P6", new DateTime(2015, 9, 8, 9, 0, 0), new Intervenant("Blanchard", "Michel"));

            Prestation p6 = new Prestation("P5", new DateTime(2015, 9, 10, 6, 0, 0), new Intervenant("Tournier", "Hélène"));

            undossier.AjoutePrestation(p1);
            undossier.AjoutePrestation(p2);
            undossier.AjoutePrestation(p3);
            undossier.AjoutePrestation(p4);
            undossier.AjoutePrestation(p5);
            undossier.AjoutePrestation(p6);

            Console.WriteLine(undossier.ToString());
            Console.WriteLine("-------------Fin dossier --------------");

        }
        public static void TestGetNbPrestationsI()
        {
            Intervenant i = new Intervenant("Garonne", "Roger");
            Prestation p1 = new Prestation("P1", new DateTime(2021, 09, 15), i);
            Prestation p2 = new Prestation("P2", new DateTime(2021, 09, 10), i);
            i.AjoutePrestation(p1.Libelle, p1.DateHeureSoin);
            i.AjoutePrestation(p2.Libelle, p2.DateHeureSoin);
            Console.WriteLine(i.GetNbPrestations());
        }
        public static void TestGetNbPrestationsIE()
        {
            IntervenantExterne iExt = new IntervenantExterne("Garonne", "Roger", "Neurologie", "Rue du soleil", 0678452568);
            Prestation p1 = new Prestation("P1", new DateTime(2021, 09, 20), iExt);
            Prestation p2 = new Prestation("P2", new DateTime(2021, 09, 17), iExt);
            Prestation p3 = new Prestation("P3", new DateTime(2021, 09, 18), iExt);
            iExt.AjoutePrestation(p1.Libelle, p1.DateHeureSoin);
            iExt.AjoutePrestation(p2.Libelle, p2.DateHeureSoin);
            iExt.AjoutePrestation(p3.Libelle, p3.DateHeureSoin);
            Console.WriteLine(iExt.GetNbPrestations());
        }
        public static bool TestDateDossierPrestationOK()
        {
            try
            {
                List<Prestation> listePrestations = new List<Prestation>();
                Dossier undossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3), new DateTime(2009, 07, 1), listePrestations);


                Prestation p1 = new Prestation("P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));

                Prestation p2 = new Prestation("P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", 0202020202));

                Prestation p3 = new Prestation("P2", new DateTime(2015, 9, 8, 12, 0, 0), new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", 0303030303));

                Prestation p4 = new Prestation("P4", new DateTime(2015, 9, 20, 12, 0, 0), new Intervenant("Maurin", "Joëlle"));

                Prestation p5 = new Prestation("P6", new DateTime(2015, 9, 8, 9, 0, 0), new Intervenant("Blanchard", "Michel"));

                Prestation p6 = new Prestation("P5", new DateTime(2015, 9, 10, 6, 0, 0), new Intervenant("Tournier", "Hélène"));

                undossier.AjoutePrestation(p1);
                undossier.AjoutePrestation(p2);
                undossier.AjoutePrestation(p3);
                undossier.AjoutePrestation(p4);
                undossier.AjoutePrestation(p5);
                undossier.AjoutePrestation(p6);

                return true;
            }
            catch (SoinsException)
            {
                return false;
            }
        }
        public static bool TestDateDossierPrestationKO()
        {
            try
            {
                List<Prestation> listePrestations = new List<Prestation>();
                Dossier undossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3), new DateTime(2050, 04, 1), listePrestations);


                Prestation p1 = new Prestation("P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));

                Prestation p2 = new Prestation("P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", 0202020202));

                Prestation p3 = new Prestation("P2", new DateTime(2015, 9, 8, 12, 0, 0), new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", 0303030303));

                Prestation p4 = new Prestation("P4", new DateTime(2015, 9, 20, 12, 0, 0), new Intervenant("Maurin", "Joëlle"));

                Prestation p5 = new Prestation("P6", new DateTime(2015, 9, 8, 9, 0, 0), new Intervenant("Blanchard", "Michel"));

                Prestation p6 = new Prestation("P5", new DateTime(2015, 9, 10, 6, 0, 0), new Intervenant("Tournier", "Hélène"));

                undossier.AjoutePrestation(p1);
                undossier.AjoutePrestation(p2);
                undossier.AjoutePrestation(p3);
                undossier.AjoutePrestation(p4);
                undossier.AjoutePrestation(p5);
                undossier.AjoutePrestation(p6);

                return false;
            }
            catch (SoinsException)
            {
                return true;
            }
        }
        public static bool TestDatePrestationOK()
        {
            try
            {
                Prestation p = new Prestation("test", new DateTime(2015, 09, 10), new Intervenant("Dupont", "Jean"));

                return true;
            }
            catch (SoinsException)
            {

                return false;
            }
        }
        public static bool TestDatePrestationKO()
        {
            try
            {
                Prestation p = new Prestation("test", new DateTime(2050, 09, 28), new Intervenant("Dupont", "Jean"));

                return false;
            }
            catch (SoinsException)
            {

                return true;
            }
        }
        public static bool TestDateDossierNaissanceOK()
        {
            try
            {
                Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1980, 09, 10));

                return true;
            }
            catch (SoinsException)
            {

                return false;
            }
        }
        public static bool TestDateDossierNaissanceKO()
        {
            try
            {
                Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(2050, 04, 01));

                return false;
            }
            catch (SoinsException)
            {

                return true;
            }
        }
        public static bool TestDateDossierCreationOK()
        {
            try
            {
                Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1980, 09, 10), new DateTime(2015, 09, 10));

                return true;
            }
            catch (SoinsException)
            {

                return false;
            }
        }
        public static bool TestDateDossierCreationKO()
        {
            try
            {
                Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1980, 09, 10), new DateTime(2025, 04, 01));

                return false;
            }
            catch (SoinsException e)
            {
                //ExceptionLog(e);
                return true;
            }
        }
        public static void ExceptionLog(Exception e)
        {
            var erreur = new Dictionary<string, string>
            {
                { "Soins2021", e.Source.ToString()},
                { "ClasseException", "SoinsException"},
                { "DateException", DateTime.Now.ToString()},
                { "MessageException", e.Message},
                { "UserException", Environment.UserName},
                { "UserMachine", Environment.MachineName}
            };
            //foreach (DictionaryEntry data in e.Data)
            //{
            //    erreur.Add(data.Key.ToString(), data.Value.ToString());
            //}
            string json = JsonConvert.SerializeObject(erreur, Formatting.Indented);


            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new StringContent(json);
            string filePath = @"E:\BTS SIO 2\ROCHE\REVISIONS TP\ExceptionData.json";
            File.AppendAllText(filePath, json);
        }



        // BONUS
        //internal static void TesteDossierTrieDatePrestation()
        //{
        //    List<Prestation> listeTriee = new List<Prestation>();
        //    Dossier unDossier = new Dossier("Robert", "Jean", new DateTime(1980, 12, 3), listeTriee);

        //    // Les prestations sont triées par date
        //    Prestation p1 = new Prestation("Libelle P1", new DateTime(2015, 9, 1, 12, 0, 0), new IntervenantExterne("Durand", "Annie", "Cardiologue", "Marseille", 0202020202));
        //    unDossier.AjoutePrestation(p1);

        //    Prestation p2 = new Prestation("Libelle P2", new DateTime(2015, 9, 8, 12, 50, 0), new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", 0303030303));
        //    unDossier.AjoutePrestation(p2);
        //    Prestation p3 = new Prestation("Libelle P6", new DateTime(2015, 9, 8, 14, 30, 0), new Intervenant("Blanchard", "Michel"));
        //    unDossier.AjoutePrestation(p3);

        //    Prestation p4 = new Prestation("Libelle P3", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));
        //    unDossier.AjoutePrestation(p4);
        //    Prestation p5 = new Prestation("Libelle P3", new DateTime(2015, 9, 10, 16, 0, 0), new Intervenant("Dupont", "Jean"));
        //    unDossier.AjoutePrestation(p5);
        //    Prestation p6 = new Prestation("Libelle P5", new DateTime(2015, 9, 10, 16, 30, 0), new Intervenant("Tournier", "Hélène"));
        //    unDossier.AjoutePrestation(p6);

        //    Prestation p7 = new Prestation("Libelle P4", new DateTime(2015, 9, 20, 12, 0, 0), new Intervenant("Maurin", "Joëlle"));
        //    unDossier.AjoutePrestation(p7);
        //    Prestation p8 = new Prestation("Libelle P4", new DateTime(2015, 9, 20, 12, 30, 0), new Intervenant("Maurin", "Joëlle"));
        //    unDossier.AjoutePrestation(p8);

        //    /*
        //     *  A Faire : Calculer er afficher le nombre de jours de prestations 
        //     *  en parcourant la liste des prestations triée sur les dates de prestations
        //     * 
        //     */

        //}
        //public static int GetNbJoursPrestations(List<Prestation> listeTriee)
        //{
        //    DateTime comparatif = listeTriee[0].DateHeureSoin.Date;
        //    int cpt = 1;
        //    foreach (Prestation p in listeTriee)
        //    {
        //        if (comparatif != p.DateHeureSoin.Date)
        //        {
        //            cpt++;
        //            comparatif = p.DateHeureSoin.Date;
        //        }
        //    }
        //    return cpt;
        //}




    }
}
