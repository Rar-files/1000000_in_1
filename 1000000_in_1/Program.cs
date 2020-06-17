using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace _1000000_in_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool badValue = false;
            int page = 0;
            while (true)
            {
                badValue = startMsg(badValue);



                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[{page + 1}]");
                Console.WriteLine($"[{page + 2}]");
                Console.WriteLine($"[{page + 3}]");
                Console.WriteLine($"[{page + 4}]");
                Console.WriteLine($"[{page + 5}]");
                Console.WriteLine($"[{page + 6}]");
                Console.WriteLine($"[{page + 7}]");
                Console.WriteLine($"[{page + 8}]");
                Console.WriteLine($"[{page + 9}]");
                Console.WriteLine($"[{page + 10}]");

                Console.ForegroundColor = ConsoleColor.DarkCyan;

                string bufor;
                if (page == 0)
                {
                    Console.WriteLine($"              Page {(page + 10) / 10} > ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Aby zmienić stronę wpisz \">\"");
                    bufor = Console.ReadLine();
                    if (bufor == ">")
                        page += 10;
                }
                else if (page == 100000)
                {
                    Console.WriteLine($"            < Page {(page + 10) / 10}   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Aby zmienić stronę wpisz \"<\"");
                    bufor = Console.ReadLine();
                    if (bufor == "<")
                        page -= 10;
                }
                else
                {
                    Console.WriteLine($"            < Page {(page + 10) / 10} > ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Aby zmienić stronę wpisz \"<\" lub \">\"");
                    bufor = Console.ReadLine();
                    if (bufor == "<")
                        page -= 10;
                    else if (bufor == ">")
                        page += 10;
                }

                try
                {                   
                    switch (int.Parse(bufor)-page)
                    {
                        case 1:
                            break;

                        default:
                            badValue = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                }


                Console.Clear();
            }

        }

        static bool startMsg(bool badValue)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Witaj w istnej ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("RETRO");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("spekcji!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Czyli grze, mającej na celu przywołać wspomnienia kartridży kupowanych na jarmarkach obiecujących nam aż");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" 1 000 000 GIER!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Poniżej znajdziesz menu wyboru kilku prostych gierek logicznych.");
            Console.WriteLine("(Oczywiście jak to na tamte czasy przystało, to nie do końca 1 000 000 osobnych gierek ;)");

            Console.WriteLine();
            if (badValue)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Wpisz poprawną wartość!");
                badValue = false;
            }
            else
                Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Aby dokonać wyboru, wpisz Id gry");

            return badValue;
        }
    }
}
