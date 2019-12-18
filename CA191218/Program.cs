using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191218
{
    struct Diak
    {
        public string vNev;
        public string kNev;
        public int magassag;
        public float suly;
        public string nem;
    }
    class Program
    {
        static Diak[] diakok = new Diak[100];
        static void Main(string[] args)
        {
            Beolvas();
            DbLany();
            AtlagMagassag();
            Console.ReadKey();
        }

        private static void AtlagMagassag()
        {
            int sum = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                sum += diakok[i].magassag;
            }
            Console.WriteLine("Az átlagos magasság: {0:0.00} cm", sum / (float)diakok.Length);
        }

        private static void DbLany()
        {
            int db = 0;
            for (int i = 0; i < diakok.Length; i++)
            {
                if (diakok[i].nem == "lány") db++;
            }
            Console.WriteLine($"Összesen {db} db lány van.");
        }

        static void Beolvas()
        {
            var sr = new StreamReader("diakok.txt", Encoding.UTF8);

            for (int i = 0; i < diakok.Length; i++)
            {
                string[] sor = sr.ReadLine().Split(' ');

                diakok[i] = new Diak()
                {
                    vNev = sor[0],
                    kNev = sor[1],
                    magassag = int.Parse(sor[2]),
                    suly = float.Parse(sor[3]),
                    nem = sor[4],
                };
            }
            sr.Close();
        }
    }
}
