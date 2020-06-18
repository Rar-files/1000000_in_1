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
            bool badValue = false;
            int page = 0;
            while (true)
            {
                int parametr = rnd.Next(2, 11);
                int parametrPage = page / 10 + 1;

                badValue = StartMsg(badValue,parametr,page);

                string bufor;
                if (page == 0)
                {
                    bufor = Console.ReadLine();
                    if (bufor == ">")
                        page += 10;
                } //Zmiana strony
                else if (page == 100000)
                {
                    bufor = Console.ReadLine();
                    if (bufor == "<")
                        page -= 10;
                }
                else
                {
                    bufor = Console.ReadLine();
                    if (bufor == "<")
                        page -= 10;
                    else if (bufor == ">")
                        page += 10;
                }

                try //przechwytywanie numeru z wejścia przy pomocy warunku FormatException zgłaszanego przez int.Parse()
                {
                    badValue = CaseMenu(int.Parse(bufor) - page, parametr, parametrPage);               
                }
                catch (FormatException)
                {
                }


                Console.Clear();
            }

        }

        static bool StartMsg(bool badValue, int parametr, int page)
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

            return badValue;
        } //Stały element interfejsu (Flaga informująca o tym czy wpisana wartość była błędna, parametr do gier, numer strony)

        static bool CaseMenu(int n, int parametr, int parametrPage)
        {
            switch (n)
            {
                case 1:
                    BUM(parametr, parametrPage); //inicjowanie gry BUM
                    break;

                case 2:
                    RACHMISTRZ(parametrPage);
                    break;

                default:
                    return true; //zwrot informacji o złej wartości
            }//Wybór pozycji z menu
            return false;
        }//Wybór gry. funkcja wyciągnięta, aby wraz z rozwojem ilości gier nie ingerować w główną strukture programu main

        static void BUM(int bumINT, int Start)
        {
            int pktSI = 0;
            int pktPlayer = 0;

            Game:

            BumGame.Regulamin(Start,bumINT);

            while (true)
            {
                for (int i = Start; true; i++)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Aktualny wynik: Komputer {pktSI}:{pktPlayer} Gracz");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    string bufor;
                    bool flagaSI = false;

                    if (i%2!=0)
                    {
                        Console.Write("Moja kolej: ");
                        bufor = BumGame.Si(bumINT, i, Start);
                        Console.WriteLine(bufor);
                        Thread.Sleep(500);
                        flagaSI = true;
                    } //Przechwycenie testu
                    else
                    {
                        Console.Write("Twoja kolej: ");
                        bufor = Console.ReadLine();
                    }
                    

                    try
                    {
                        if (BumGame.IfBUM(bumINT, int.Parse(bufor)))
                        {
                            goto Lose;
                        }
                        else if (int.Parse(bufor) == i) { goto Continue; }
                        else
                        {
                            goto Lose;
                        }

                    }

                    catch (FormatException)
                    {
                        if (BumGame.IfBUM(bumINT, i))
                        {
                            if (bufor != "BUM")
                            {
                                goto Lose;
                            }
                            goto Continue;
                        }
                        else
                        {
                            goto Lose;
                        }
                    }

                    Lose:
                    if (flagaSI)
                    {
                        Console.WriteLine("ojjj, moja wina :/ punkty lecą do cb.");
                        pktPlayer++;
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ha! Mam cię, ta runda jest moja");
                        pktSI++;
                        Console.ReadKey();
                        break;
                    }

                Continue:;

                }

                if (pktSI == 3)
                {                    
                    Console.WriteLine("Wygrałem!");
                    goto Win;
                }
                if (pktPlayer == 3)
                {
                    Console.WriteLine("Gratuluje wygranej!");
                    goto Win;
                }
                else goto Rerun;

                Win:
                Console.WriteLine("Chcesz spróbować jeszcze raz?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Odpowiedz tak/nie");
                Reload:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string buforYN = Console.ReadLine();
                if (buforYN == "tak")
                {
                    pktPlayer = 0;
                    pktSI = 0;
                    Console.Clear();
                    Console.WriteLine("To w ramach powtórzenia...");
                    Thread.Sleep(2000);
                    goto Game; }
                else if (buforYN == "nie") break;
                else { Console.WriteLine("Wybierz tak lub nie."); goto Reload; }

                Rerun:;
            }

        } //Gra w BUM

        static void RACHMISTRZ(int n)
        {
            while (true)
            {
            Game:

                Rachmistrz.Regulamin(n);

                Console.WriteLine("Start");
                Console.ForegroundColor = ConsoleColor.White;
                int CorrectAnswer = Rachmistrz.Game(n);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Stop");
                Console.WriteLine();

                Odpowiedz:
                Console.Write("Twoja odpowiedź: ");
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    if (CorrectAnswer == int.Parse(Console.ReadLine()))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Brawo!, jest to poprawna odpowiedź");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Niestety, jest to błędna odpowiedź.");
                        Console.WriteLine("Powinno być: " + CorrectAnswer);
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine( );                    
                    Console.WriteLine("Wpisz liczbę!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    goto Odpowiedz;
                }

                Console.WriteLine("Chcesz spróbować jeszcze raz?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Odpowiedz tak/nie");
                Reload:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string buforYN = Console.ReadLine();
                if (buforYN == "tak")
                {
                    Console.Clear();
                    Console.WriteLine("To w ramach powtórzenia...");
                    Thread.Sleep(2000);
                    goto Game;
                }
                else if (buforYN == "nie") break;
                else { Console.WriteLine("Wybierz tak lub nie."); goto Reload; }

            }
        }
    }
}
