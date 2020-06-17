using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            bool badValue = false;
            int page = 0;
            while (true)
            {
                badValue = startMsg(badValue);

                int parametr = rnd.Next(2, 11);
                int parametr2 = (page + 10) / 10;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[{page + 1}] BUM - gracze naprzemiennie liczą od {parametr2}, w momencie gdy jakaś liczba jest podzielna lub zawiera w sobie {parametr} piszą \"BUM\"");
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
                            BUM(parametr, parametr2);
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

        static void BUM(int bumINT, int Start)
        {
            int pktSI = 0;
            int pktPlayer = 0;

            BumGame.Regulamin(Start,bumINT);

            while (true)
            {
                for (int i = Start; true; i += 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Aktualny wynik: Komputer {pktSI}:{pktPlayer} Gracz");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    string bufor = BumGame.Si(bumINT, i, Start);

                    Console.WriteLine(bufor);
                    Thread.Sleep(500);

                    try
                    {
                        if (BumGame.Game(bumINT, int.Parse(bufor)))
                        {
                            Console.WriteLine("ojjj, moja wina :/ punkty lecą do cb.");
                            pktPlayer++;
                            Console.ReadKey();
                            break;
                        }
                        //else if (int.Parse(bufor)!=i)
                        //{
                        //    Console.WriteLine("ojjj, moja wina :/ punkty lecą do cb.");
                        //    pktPlayer++;
                        //    Console.ReadKey();
                        //    break;
                        //}

                    }

                    catch (FormatException)
                    {
                        if (bufor != "BUM")
                        {
                            Console.WriteLine("ojjj, moja wina :/ punkty lecą do cb.");
                            pktPlayer++;
                            Console.ReadKey();
                            break;                            
                        }
                    }

                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Aktualny wynik: Komputer {pktSI}:{pktPlayer} Gracz");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    bufor = Console.ReadLine();

                    try
                    {
                        if (BumGame.Game(bumINT, int.Parse(bufor)))
                        {
                            Console.WriteLine("Ha! Mam cię, ta runda jest moja");
                            pktSI++;
                            Console.ReadKey();
                            break;
                        }
                        //else if (int.Parse(bufor) != i+1)
                        //{
                        //    Console.WriteLine("Ha! Mam cię, ta runda jest moja");
                        //    pktSI++;
                        //    Console.ReadKey();
                        //    break;
                        //}
                    }

                    catch(FormatException)
                    {
                        if(bufor != "BUM")
                        {
                            Console.WriteLine("Ha! Mam cię, ta runda jest moja");
                            pktSI++;
                            Console.ReadKey();
                            break;
                        }
                    }

                    //int bufor = BumGame.Game(bumINT);
                    //if (bufor == 1)
                    //{
                    //    Console.WriteLine("ojjj, moja wina :/ punkty lecą do cb.");
                    //    pktPlayer++;
                    //    break;
                    //}
                    //else if (bufor == 2)

                }

                if (pktSI == 3) { Console.WriteLine("Wygrałem!"); break; }
                if (pktPlayer == 3) { Console.WriteLine("Gratuluje wygranej!"); break; }
            }

        }
    }
}
