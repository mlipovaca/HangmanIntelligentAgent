using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class AgentHangman
    {
        private List<string> pogodenaPronadenaSlova;
        private List<string> PogodenaSlova;
        private List<string> NedostajanaSlova;

        public Rijec IzabranaRijec
        {
            get;
            set;
        }

        public AgentHangman()
        {
            pogodenaPronadenaSlova = new List<string>();
            PogodenaSlova = new List<string>();
            NedostajanaSlova = new List<string>();
        }

        public void Igra()
        {
            pogodenaPronadenaSlova = new List<string>();

            for (int i = 0; i < IzabranaRijec.DuzinaRijec; i++)
            {
                pogodenaPronadenaSlova.Add(" _ ");
            }

            for (int i = 0; i < IzabranaRijec.DuzinaRijec; i++)
            {
                string slovo = IzabranaRijec.Tekst.Substring(i, 1);
                if (PogodenaSlova.Count > 0)
                {
                    foreach (string pogodenoSlovo in this.PogodenaSlova)
                    {
                        if (slovo.Equals(pogodenoSlovo.Trim().ToUpper()))
                        {
                            pogodenaPronadenaSlova.RemoveAt(i);
                            pogodenaPronadenaSlova.Insert(i, " " + slovo + " ");
                        }
                    }
                }
            }
            crtajVjesaloLika();
            Console.WriteLine(napraviString(pogodenaPronadenaSlova, false));
            Console.WriteLine();
        }

        public bool DodajPogodenoSlovo(char slovo)
        {
            if (char.IsDigit(slovo))
            {
                Console.WriteLine();
                Console.WriteLine("'" + slovo.ToString().ToUpper() + "' nije validno slovo (upisali ste znak/broj...)");
                return false;
            }
            else if (!this.PogodenaSlova.Contains(slovo.ToString().ToUpper()))
            {
                this.PogodenaSlova.Add(slovo.ToString().ToUpper());
                Console.WriteLine();
                Console.WriteLine("Pogodena slova : " + napraviString(PogodenaSlova, true));
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Nažalost, već ste pogodili to slovo '" + slovo.ToString().ToUpper() + "'");
            }
            return false;
        }

        private bool provjeriSlovo(string slovo)
        {
            for (int i = 0; i < IzabranaRijec.DuzinaRijec; i++)
            {
                string splitedletter = IzabranaRijec.Tekst.Substring(i, 1).ToUpper();
                if (splitedletter.Equals(slovo.Trim().ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        private string napraviString(List<string> inputString, bool razmak)
        {
            StringBuilder rezultat = new StringBuilder();
            foreach (object item in inputString)
            {
                if (razmak)
                    rezultat = rezultat.Append(item.ToString().ToUpper() + " ");
                else
                    rezultat = rezultat.Append(item.ToString().ToUpper());

            }
            return rezultat.ToString();
        }

        private void crtajVjesaloLika()
        {

            NedostajanaSlova = new List<string>();
            foreach (string item in PogodenaSlova)
            {
                if (!provjeriSlovo(item))
                {
                    NedostajanaSlova.Add(item);
                }
            }

            Console.WriteLine();
            if (NedostajanaSlova.Count == 1)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else if (NedostajanaSlova.Count == 2)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else if (NedostajanaSlova.Count == 3)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else if (NedostajanaSlova.Count == 4)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");

            }
            else if (NedostajanaSlova.Count == 5)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else if (NedostajanaSlova.Count == 6)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |    /");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else if (NedostajanaSlova.Count == 7)
            {
                Console.WriteLine("   _____");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |     O");
                Console.WriteLine("  |    \\|/");
                Console.WriteLine("  |     |");
                Console.WriteLine("  |    / \\");
                Console.WriteLine("  |");
                Console.WriteLine("__|__");
            }
            else
                Console.WriteLine();
            Console.WriteLine();
        }

        public RezultatIgre Rezultat()
        {
            if (NedostajanaSlova.Count == 7)
            {
                return RezultatIgre.GUBITAK;
            }
            else if (IzabranaRijec.Tekst.ToUpper().Equals(napraviString(pogodenaPronadenaSlova, false).Replace(" ", "")))
            {
                return RezultatIgre.POBJEDA;
            }
            else
                return RezultatIgre.NASTAVAK;
        }
    }
}
