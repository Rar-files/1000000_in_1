using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using ClassLibrary;

namespace _1000000_in_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int page = 0;
            string badValue = "";

            while (true)
            {
                int parametr = rnd.Next(2, 11);

                GUI(badValue,parametr,page);
                badValue = "";

                try
                {
                    page = GameList.List(parametr, page);
                }

                catch (ArgumentException x)
                {
                    badValue = x.Message;
                }

                catch (FormatException x)
                {
                    badValue = x.Message;
                }

                catch(Exception)
                {
                    GUIend();
                }

                Console.Clear();
            }

        }

        static void GUI(string badValue, int parametr, int page)
        {
            int parametrPage = page / 10 + 1;

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

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(badValue);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Aby dokonać wyboru, wpisz Id gry");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{page + 1}] BUM - gracze naprzemiennie liczą od {parametrPage}, w momencie gdy jakaś liczba jest podzielna/zawiera w sobie {parametr} piszą \"BUM\"");
            Console.WriteLine($"[{page + 2}] Rachmistrz - program losuje {parametrPage} razy liczby od 1-9, a twoim zadaniem jest podać poprawną sumę.");
            Console.WriteLine($"[{page + 3}]");
            Console.WriteLine($"[{page + 4}]");
            Console.WriteLine($"[{page + 5}]");
            Console.WriteLine($"[{page + 6}]");
            Console.WriteLine($"[{page + 7}]");
            Console.WriteLine($"[{page + 8}]");
            Console.WriteLine($"[{page + 9}]");
            Console.WriteLine($"[{page + 10}]");

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (page == 0)
            {
                Console.WriteLine($"              Page {parametrPage} > ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Aby zmienić stronę wpisz \">\"");
            }
            else if (page == 100000)
            {
                Console.WriteLine($"            < Page {parametrPage}   ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Aby zmienić stronę wpisz \"<\"");
            }
            else
            {
                Console.WriteLine($"            < Page {parametrPage} > ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Aby zmienić stronę wpisz \"<\" lub \">\"");

            }
            Console.WriteLine("Aby zakończyć program wpisz \"x\"");

        } //Stały element interfejsu (Informacja o błędzie, parametr do gier, numer strony)

        static void GUIend()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Czy napewno chcesz wyłączyć program?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Odpowiedz tak/nie");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            while (true)
            {
                string buforYN = Console.ReadLine();
                if (buforYN == "tak")
                {
                    Environment.Exit(0);
                }
                else if (buforYN == "nie") break;
                else Console.WriteLine("Wybierz \"tak\" lub \"nie\".");
            }

        }
    }
}
