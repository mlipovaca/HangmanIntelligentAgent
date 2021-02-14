using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("|      DOBRODOŠLI U IGRU VJEŠALA SA AGENTOM       |");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Cilj igre je pogoditi riječ, imate 7 pokušaja sveukupno!");
            string odgovor = string.Empty;
            do
            {
                Console.WriteLine();
                odgovor = IgrajIgru();
            }
            while (odgovor.ToUpper().Equals("Y"));
            Console.ReadLine();
        }

        private static string IgrajIgru()
        {
            ListaRijeci listaRijeci = new ListaRijeci();
            Rijec rijec = listaRijeci.RandomOdabir;
            AgentHangman agent = new AgentHangman();
            agent.IzabranaRijec = rijec;
            ConsoleKeyInfo Odgovor = new ConsoleKeyInfo();

            for (int i = 0; i < rijec.DuzinaRijec; i++)
            {
                Console.Write(" _ ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            while (agent.Rezultat() == RezultatIgre.NASTAVAK)
            {
                Console.Write("Izaberite slovo --> ");
                ConsoleKeyInfo upisanoSlovo = Console.ReadKey();
                if (agent.DodajPogodenoSlovo(upisanoSlovo.KeyChar))
                {
                    agent.Igra();
                }
            }
            
            if (agent.Rezultat() == RezultatIgre.GUBITAK)
            {
                Console.WriteLine("Izgubili ste igru, žao mi je!");
                Console.WriteLine();
                UrediTekstVizualno("Ponuđena riječ je bila '" + rijec.Tekst.ToUpper() + "'", 500);
                Console.Write("Želite li ponovo zaigrati (Y/N): ");
                Odgovor = Console.ReadKey();
                return Odgovor.KeyChar.ToString();
            }
            else
            {
                UrediTekstVizualno("Pobijedili ste!", 500);
                Console.WriteLine();
                Console.Write("Želite li ponovo zaigrati (Y/N): ");
                Odgovor = Console.ReadKey();
                return Odgovor.KeyChar.ToString();
            }
        }

        private static void NapraviTekstVizualno(string tekst, int odgoda, bool vidljivost)
        {
            if (vidljivost)
                Console.Write(tekst);
            else
                for (int i = 0; i < tekst.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= tekst.Length;
            Thread.Sleep(odgoda);
        }

        private static void UrediTekstVizualno(string tekst, int odgoda)
        {
            for (int i = 0; i < 5; i++)
            {
                NapraviTekstVizualno(tekst, odgoda, true);
                NapraviTekstVizualno(tekst, 500, false);
            }
        }
    }
}
