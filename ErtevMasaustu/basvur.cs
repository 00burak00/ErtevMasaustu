using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ErtevMasaustu
{
    public class basvur
    {
        string ad;
        string soyad;
        string mail;
        string tel;
        DateTime date;

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Tel { get => tel; set => tel = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}