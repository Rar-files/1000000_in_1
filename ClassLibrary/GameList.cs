﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassLibrary
{
    public class GameList
    {
        public static int List(int parametr, int page)
        {
            int parametrPage = page / 10 + 1;
            string bufor;

            bufor = Console.ReadLine();

            try //przechwytywanie numeru z wejścia przy pomocy warunku FormatException zgłaszanego przez int.Parse()
            {
                CaseMenu(int.Parse(bufor) - page, parametr, parametrPage);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Błędny numer ID");
            }

            catch (FormatException)
            {
                
                if (bufor == ">")
                {
                    if (page == 100000)
                        goto Warunek;
                    else
                    {
                        page += 10;
                        goto BrakWarunku;
                    }
                } //Zmiana strony
                else if (bufor == "<")
                {
                    if (page == 0)
                        goto Warunek;
                    else
                    {
                        page -= 10;
                        goto BrakWarunku;
                    }
                }
                else if (bufor == "x")
                {
                    throw new Exception("Koniec pracy programu.");
                }
                else
                {
                    goto Warunek;
                }

                Warunek:
                if (page == 100000)
                    throw new FormatException("Błędna wartość, dozwolone liczby lub \"<\".");
                else if (page == 0)
                    throw new FormatException("Błędna wartość, dozwolone liczby lub \">\".");
                else
                    throw new FormatException("Błędna wartość, dozwolone liczby lub \"<\" \">\".");

                BrakWarunku:;

            }

            return page;
        }

        static void CaseMenu(int n, int parametr, int parametrPage)
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
                    throw new ArgumentException("Brak Takiej Gry.");
                     //zwrot informacji o złej wartości
            }//Wybór pozycji z menu
        }//Wybór gry. funkcja wyciągnięta, aby wraz z rozwojem ilości gier nie ingerować w główną strukture programu main

        static void BUM(int bumINT, int Start)
        {
            int pktSI = 0;
            int pktPlayer = 0;

        Game:

            BumGame.Regulamin(Start, bumINT);

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

                    if (i % 2 != 0)
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
                    goto Game;
                }
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
                catch (FormatException)
                {
                    Console.WriteLine();
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