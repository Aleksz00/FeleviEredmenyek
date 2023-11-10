using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FeleviEredmenyek
{
    class Program
    {
        static double atlag(List<felevi> a)
        {

            return a.Average(x => x.atlagSzam);
        }

        //static List<felevi> progi(List<felevi> b)
        //{
        //  var progi =b.Where(x => x.Programozas == 1 || x.ProgramozasGyak == 1).ToList();
        //    return progi;

        // }
        static List<felevi> tan(List<felevi> b)
        {
            
            var tantargyankent = new List<double>();
            for (int i = 0; i < 8; i++)
            {
                tantargyankent.Add(0); 
            }
            for (int i = 0; i < b.Count; i++)
            {
                for (int a = 0; a < b[i].jegyek[a]; a++)
                {
                    tantargyankent[a] += b[i].jegyek[a];
                }

            }
            for (int i = 0; i < tantargyankent.Count; i++)
            {
                tantargyankent[i] =tantargyankent[i]/8;

               
            }
           
        }

        static void kiir(List<felevi> f)
        {
            using (var sw = new StreamWriter(@"..\..\src\adatok.txt"))
            {
                for (int i = 0; i < f.Count; i++)
                {
                    sw.WriteLine($"{f[i].TanuloNev}, {f[i].OktatasiAzonosito}");
                }
            }
        }
        static void Main(string[] args)
        {
            var felevik = new List<felevi>();
            using (var sr = new StreamReader(@"..\..\..\src\felevi.txt.txt",Encoding.UTF8))
            {
                var tantargyak = sr.ReadLine().Split("\t").Skip(2).ToList();
                while (!sr.EndOfStream)
                {
                    felevik.Add(new felevi(sr.ReadLine(),tantargyak));
                    sr.ReadLine();
                }
                
            }
            Console.WriteLine(felevik.Count);


            Console.WriteLine($"1.feladat: {atlag(felevik)}");
            Console.WriteLine($"1.2.feladat");
            Console.WriteLine($"1.3.feladat:");
            Console.WriteLine("2.feladat");
            var f2 = felevik.Where(x => x.jegyek[3] == 1).ToList();
            Console.WriteLine(f2);
            foreach (var item in felevik)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("3.feladat");
            var f3=felevik.FirstOrDefault(t => t.jegyek[4] == 3);
            Console.WriteLine(f3);
            Console.WriteLine("4.feladat");
            Console.Write("Kinek a legjobb jegyet szeretned?: ");
            string nev = Console.ReadLine();
            var kival = felevik.FirstOrDefault(t => t.TanuloNev == nev);
            Console.WriteLine($"{kival.LegjobbJegy}");

            Console.WriteLine("5.feladat");
            kiir(felevik);


        }
    }
}
