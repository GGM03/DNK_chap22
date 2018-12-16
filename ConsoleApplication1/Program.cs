using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    class DNK
    {
        public string a;
        public DNK()
        {
            a = "ATGCA";
        }
        public DNK(int aa)
        {
            a = "";
            Random r = new Random();
            for (int i = 0; i < aa; i++)
            {

                int b = r.Next(0, 4);
                switch (b)
                {
                    case 0:
                        { a = a + "A"; break; }
                    case 1:
                        { a = a + "G"; break; }
                    case 2:
                        { a = a + "C"; break; }
                    case 3:
                        { a = a + "T"; break; }
                }
            }

        }
        public DNK(string s)
        {
            a = s;
        }
        public static DNK BuildWright(DNK ss)
        {
            string r = "";
            for (int i = 0; i < ss.a.Length; i++)
            {
                if (ss.a[i] == 'A')
                { r = r + "T"; }
                else if (ss.a[i] == 'G')
                { r = r + "C"; }
                else if (ss.a[i] == 'T')
                { r = r + "A"; }
                else
                { r = r + "G"; }
            }
            DNK rr = new DNK(r);
            return rr;
        }
        public static int Check(DNK h, DNK hh)
        {
            int k = 0;
            for (int i = 0; i < h.a.Length; i++)
            {
                if (h.a[i] == hh.a[i])
                {
                    k++;
                }
            }
            return k;

        }
        public void Output()
        {
            DNK j = new DNK(a);
            Console.WriteLine(a);
            DNK k = BuildWright(j);
            Console.WriteLine(k.a);
        }
        public static double[] operator %(DNK v, double s)
        {
            double A = 0, G = 0, C = 0, T = 0;
            for (int i = 0; i < v.a.Length; i++)
            {
                if (v.a[i] == 'A') A++;
                else if (v.a[i] == 'T') T++;
                else if (v.a[i] == 'G') G++;
                else if (v.a[i] == 'C') C++;
            }
            double[] mas = new double[4];
            mas[0] = A / v.a.Length * s;
            mas[1] = T / v.a.Length * s;
            mas[2] = C / v.a.Length * s;
            mas[3] = G / v.a.Length * s;
            Console.WriteLine("Ввывод процентного соотношения:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(mas[i]);
            }
            return mas;
        }
        public int[] this[char X]
        {

            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == X) count++;
                }
                int[] mas = new int[count];
                int k = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == X) { mas[k] = i; k++; }
                }
                return mas;
            }
        }
        public int OnlyRead
        {
            get
            {
                return a.Length;
            }

        }
    }
    class Program
    {
        static void Main()
        {


            Console.WriteLine("ВВедите размер 1 желаемой ДНК:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            DNK c1 = new DNK(n1);
            Console.WriteLine("ВВедите размер 2 желаемой ДНК:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            DNK c2 = new DNK(n2);
            Console.WriteLine("\tПалиндром 1 ДНК:");
            DNK cc = DNK.BuildWright(c1);
            cc.Output();
            Console.WriteLine("\tПалиндром 2 ДНК:");
            DNK ccc = DNK.BuildWright(c2);
            ccc.Output();
            Console.WriteLine("\t\tCompering 1,2 ДНК:");
            int test = DNK.Check(c1, c2);
            if(test==c1.a.Length)
                Console.WriteLine(" ДНКs are the same");
            else Console.WriteLine("ДНКs are different");
            Console.WriteLine("------------------ 1 ДНК:------------------");
            c1.Output();
            Console.WriteLine("------------------ 2 ДНК:------------------");
            c2.Output();

            double s = 100;
            Console.WriteLine("\t\t\t 1 ДНК:");
            double[] mas1 = c1 % s;
            Console.WriteLine("\t\t\t 2 ДНК:");
            double[] mas2 = c2 % s;

            Console.WriteLine("\nZадайте параметр азотистого основания 1 ДНК, мы вернем его индекс:");

            char l = Convert.ToChar(Console.ReadLine());
            int[] m = c1[l];
           
            Console.ReadKey();

        }
    }
}


