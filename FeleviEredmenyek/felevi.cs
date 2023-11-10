using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FeleviEredmenyek
{
    class felevi
    {
        private List<string> tantargyak;
        public string TanuloNev { get; set; }
        public string OktatasiAzonosito { get; set; }
        public List<int> jegyek;
        public double Osztalyatlag { get; set; }

        public double LegjobbJegy =>jegyek.Max();




        public felevi(string r , List<string>tantargyak)
        {
            string[] s = r.Split("\t");
            TanuloNev = s[0];
            OktatasiAzonosito =s[1];
            jegyek = new List<int>();
            for (int i = 2; i < s.Length; i++)
            {
                jegyek.Add(int.Parse(s[i]));
            }
            this.tantargyak = tantargyak;
        }

        public double atlagSzam => jegyek.Average();
       

        
        
        public override string ToString()
        {
            string osztalyzat = $"Tanuló Neve: {TanuloNev}, Oktatási azonosito: {OktatasiAzonosito}, Jegyek:  ";
            for (int i = 0; i < jegyek.Count; i++)
            {
                osztalyzat += "\n";
                osztalyzat += tantargyak[i]+" "+ jegyek[i];  
            
            }
            return osztalyzat ;
        }
    }
}
