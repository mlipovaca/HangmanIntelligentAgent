using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Rijec
    {
        public string Tekst { get; set; }

        public Rijec()
        {
        }

        public Rijec(string tekst)
        {
            this.Tekst = tekst;
        }

        public int DuzinaRijec
        {
            get
            {
                return this.Tekst.Length;
            }
        }
    }
}
