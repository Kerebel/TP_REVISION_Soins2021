using Soins2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Traitement.TestDossier();
            //Console.WriteLine("Nb Prestations Intervenant : ");
            //Traitement.TestGetNbPrestationsI();
            //Console.WriteLine("Nb Prestations Intervenant Externe: ");
            //Traitement.TestGetNbPrestationsIE();

            Console.WriteLine("TestDateDossierPrestationOK : " + Traitement.TestDateDossierPrestationOK());
            Console.WriteLine("TestDateDossierPrestationKO :" + Traitement.TestDateDossierPrestationKO());
            Console.WriteLine("TestDatePrestationOK :" + Traitement.TestDatePrestationOK());
            Console.WriteLine("TestDatePrestationKO :"         + Traitement.TestDatePrestationKO());
            Console.WriteLine("TestDateDossierCreationOK :"    + Traitement.TestDateDossierCreationOK());
            Console.WriteLine("TestDateDossierCreationKO :"    + Traitement.TestDateDossierCreationKO());
            Console.WriteLine("TestDateDossierNaissanceOK :"   + Traitement.TestDateDossierNaissanceOK());
            Console.WriteLine("TestDateDossierNaissanceKO :"   + Traitement.TestDateDossierNaissanceKO());
            Console.ReadKey();
        }
    }
}
