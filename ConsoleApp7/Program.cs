using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        public static string printedword = "";
        static void recur(string currentword, int allnumbers, int maximalnumbers ,params int[] numbersused)
        {
            for(int i = 0; i < allnumbers; i++)
            {
                bool ok = true; ;
                for(int j = 0; j < numbersused.Length; j++)
                {
                    if (numbersused[j] == i)
                    {
                        ok = false;
                    }
                }
                if ((ok)|(numbersused.Length==maximalnumbers))
                {
                    if (numbersused.Length < maximalnumbers)
                    {
                        int[] numbersused1 = new int[numbersused.Length + 1];
                        for (int k = 0; k < numbersused.Length; k++)
                        {
                            numbersused1[k] = numbersused[k];
                        }
                        numbersused1[numbersused.Length] = i;
                        recur(currentword + i+" ", allnumbers, maximalnumbers, numbersused1);
                    }
                    else
                    {
                        if ((printedword == "")|(printedword != currentword))
                        {
                            printedword = currentword;
                            Console.WriteLine(currentword);
                        }
                    }

                }
            }
        }   
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для подсчёта А из n по k");
            bool ok = true;
            int n = 0;
            int k = 0;
            do
            {
                Console.WriteLine("Введите n");
                n = IntCheck();
                Console.WriteLine("Введите k");
                k = IntCheck();
                if (k > n)
                {
                    Console.WriteLine("k не может быть больше чем n. Повторите ввод");
                    ok = false;
                }
                else ok = true;
            } while (!ok);
            recur("", n, k, new int[0]);
            Console.ReadLine();
        }
        static int IntCheck()
        {
            int n;
            bool ok = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string s = Console.ReadLine();
            do
            {
                ok = int.TryParse(s, out n);
                if (ok == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ввод неправильный. Повторите.");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    s = Console.ReadLine();
                }
                else
                {
                    if (n <= 0)
                    {
                        ok = false;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Ввод неправильный. Повторите.");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        s = Console.ReadLine();
                    }
                }
            } while (!ok);
            Console.ForegroundColor = ConsoleColor.White;
            return (n);
        }
    }
    
}
