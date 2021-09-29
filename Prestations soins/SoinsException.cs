using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class SoinsException : Exception
    {
        //private SoinsException ex;
        public SoinsException(string message) : base(message)
        {
            var erreur = new Dictionary<string, string>
            {
                { "Soins2021", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString()},
                { "ClasseException", GetType().Name.ToString()},
                { "DateException", DateTime.Now.ToString()},
                { "MessageException", this.Message},
                { "UserException", Environment.UserName},
                { "UserMachine", Environment.MachineName}
            };
            
            string json = JsonConvert.SerializeObject(erreur, Formatting.Indented);

            // Recherche FileStream (lire le flux de donnée pour s'arrêter avant le crochet puis ajouter le nouveau contenu)
            
            string filePath = @"E:\BTS SIO 2\ROCHE\REVISIONS TP\ExceptionData.json";
            File.AppendAllText(filePath, json);
        }
        

    }
}
