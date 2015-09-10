using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht3
{
    class Pelaaja
    {

        public string etunimi { get; set; }
        public string sukunimi { get; set; }
        public string kokonimi { get { return etunimi + " " + sukunimi + ", " + seura; } }
        public string seura { get; set; }
        public double siirtohinta { get; set; }
        
        public string tulosta()
        {
            return this.kokonimi;
        }

        ~Pelaaja() {
            Debug.WriteLine("jojojo");
        }
    }
}
