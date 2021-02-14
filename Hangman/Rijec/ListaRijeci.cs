using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class ListaRijeci : List<Rijec>
    {
        public ListaRijeci()
        {
            this.Add(new Rijec() { Tekst = "AUTOMOBIL" });
            this.Add(new Rijec() { Tekst = "VAS" });
            this.Add(new Rijec() { Tekst = "FOI" });
            this.Add(new Rijec() { Tekst = "MENZA" });
            this.Add(new Rijec() { Tekst = "VARAŽDIN" });
            this.Add(new Rijec() { Tekst = "BMW" });
            this.Add(new Rijec() { Tekst = "VIŠEAGENTNISUSTAVI" });
            this.Add(new Rijec() { Tekst = "FOIJEZAKON" });
            this.Add(new Rijec() { Tekst = "LIZALICA" });
            this.Add(new Rijec() { Tekst = "ŠUMA" });
            this.Add(new Rijec() { Tekst = "DUPIN" });
            this.Add(new Rijec() { Tekst = "PAS" });
            this.Add(new Rijec() { Tekst = "MAČKA" });
            this.Add(new Rijec() { Tekst = "TELEFON" });
            this.Add(new Rijec() { Tekst = "BROD" });

        }

        public Rijec RandomOdabir
        {
            get
            {
                Random rand = new Random();
                int index = (int)(rand.NextDouble() * this.Count);
                Rijec rijec = this[index];
                rijec.Tekst = rijec.Tekst.ToUpper();
                return rijec;
            }
        }
    }
}
