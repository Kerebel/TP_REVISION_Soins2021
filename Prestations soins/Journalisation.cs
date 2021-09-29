using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soins2021
{
    class Journalisation
    {
        private string nomApp;
        private SoinsException classeException;
        private DateTime dateException;
        private string message;
        private string user;
        private string nomMachine;

        public Journalisation(string nomApp, SoinsException classeException, DateTime dateException, string message, string user, string nomMachine)
        {
            this.nomApp = nomApp;
            this.classeException = classeException;
            this.dateException = dateException;
            this.message = message;
            this.user = user;
            this.nomMachine = nomMachine;
        }

        public void EnvoiJSON()
        {

        }
    }
}
