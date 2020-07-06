using System;
using System.IO;
using System.Media;
using System.Threading;

namespace ClassLibrary
{
    public class GameList
    {
        public static string Cin { private set; get; } //wartość wpisana na wejściu

        public static int List(int parametr, int page)
        {
            int parametrPage = page / 5 + 1;

            Cin = Console.ReadLine();

            try //przechwytywanie numeru z wejścia przy pomocy warunku FormatException zgłaszanego przez int.Parse()
            {
                CaseMenu(int.Parse(Cin) - page, parametr, parametrPage);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Błędny numer ID");
            }

            catch (FormatException)
            {
                
                if (Cin == ">")
                {
                    if (page == 100000)
                        goto Warunek;
                    else
                    {
                        page += 5;
                        goto BrakWarunku;
                    }
                } //Zmiana strony
                else if (Cin == "<")
                {
                    if (page == 0)
                        goto Warunek;
                    else
                    {
                        page -= 5;
                        goto BrakWarunku;
                    }
                }
                else if (Cin == "x")
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
        } //Logika menu

        private static void CaseMenu(int n, int parametr, int parametrPage)
        {
            switch (n)
            {
                case 1:
                    BUM(parametr, parametrPage); //inicjowanie gry BUM
                    break;

                case 2:
                    RACHMISTRZ(parametrPage);
                    break;

                case 3:
                    FUNDELS(parametrPage);
                    break;

                case 4:
                    SIMON(parametrPage);
                    break;

                default:
                    throw new ArgumentException("Brak Takiej Gry.");
                     //zwrot informacji o złej wartości
            }//Wybór pozycji z menu
        }//Wybór gry.

        private static void BUM(int bumINT, int Start)
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

        private static void RACHMISTRZ(int n)
        {
            while (true)
            {

                Rachmistrz.Regulamin(n);

                Console.WriteLine("Start");
                Console.ForegroundColor = ConsoleColor.White;
                int CorrectAnswer = Rachmistrz.Game(n);
                Console.WriteLine(Rachmistrz.RndNumbers);
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
                }
                else if (buforYN == "nie") break;
                else { Console.WriteLine("Wybierz tak lub nie."); goto Reload; }

            }
        } //Gra w Rachmistrz 

        private static void FUNDELS(int n)
        {
            n++;
            FundelsGame.Regulamin(n);
            FundelsGame.InicjowanieTalli();
            Game:
            FundelsGame.Tasowanie();
            int[] table = FundelsGame.InicjowanieStolu(n);

            for (int tura = 0; tura < (FundelsGame.taliaGracz.Count + FundelsGame.taliaSi.Count)/2; tura++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Karty na stole: ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(table[i] + " ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < n; i++)
                {
                    Console.Write("^ ");
                }
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine(); Console.WriteLine();

            Player:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Twoja karta: {FundelsGame.taliaGracz[tura]}");
                Console.Write("Twoja odpowiedź: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(podaj id karty którą chcesz zamienić) ");
                int test = 0;
                try
                {
                    test = int.Parse(Console.ReadLine());
                    if (test > n)
                    {
                        Console.WriteLine("Wpisana wartość wykracza poza zakres id, spróbuj ponownie.");
                        goto Player;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wpisana wartość nie jest liczbą, spróbuj ponownie.");
                    Console.WriteLine();
                    goto Player;
                }

                try
                {
                    table = FundelsGame.TableCards(table, test, FundelsGame.taliaGracz[tura]);
                }

                catch (ArgumentException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ha! mam cię, niestety nie udało ci się :/");
                    goto Endgame;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Karty na stole: ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(table[i] + " ");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < n; i++)
                {
                    Console.Write("^ ");
                }
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine(); Console.WriteLine();

                test = FundelsGame.Si(table, FundelsGame.taliaSi[tura]);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Moja karta: {FundelsGame.taliaSi[tura]}");
                Console.Write($"Moja odpowiedź: ");
                Thread.Sleep(1000);
                Console.WriteLine(test);
                Thread.Sleep(2000);

                try
                {
                    table = FundelsGame.TableCards(table, test, FundelsGame.taliaSi[tura]);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine();
                    Console.WriteLine("ah! niestety, moja wina :/");
                    goto Endgame;
                }

            }
            Console.WriteLine("Koniec kart, a więc Remis");
        Endgame:
            Console.WriteLine();
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
            else if (buforYN != "nie") { Console.WriteLine("Wybierz tak lub nie."); goto Reload; };
        }

        private static void SIMON(int n)
        {
            while (true)
            {

                Simon.Regulamin(n);
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < n; i++)
                {                    
                    Console.Write("Simon: ");
                    string bufor = Simon.SimonSay().ToString();
                    string[] colors = Enum.GetNames(typeof(Simon.Color));

                    if (bufor == colors[0]) { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (bufor == colors[1]) { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (bufor == colors[2]) { Console.ForegroundColor = ConsoleColor.Blue; }
                    else if (bufor == colors[3]) { Console.ForegroundColor = ConsoleColor.Yellow; }
                    Console.WriteLine(bufor);
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Simon: ");
                    Thread.Sleep(200);
                    Console.Clear();
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{i + 1} kolor: ");
                    try
                    {
                        if (!Simon.PlayerSaid(Console.ReadLine()))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Zła odpowiedź :/");
                            goto End;
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Zła odpowiedź, to nie jest nazwa koloru :/");
                        goto End;
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Brawo! Dobra pamięć ;)");
            End:
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
                    Thread.Sleep(500);
                }
                else if (buforYN == "nie") break;
                else { Console.WriteLine("Wybierz tak lub nie."); goto Reload; }
            }

        } //Gra w SimonMowi
    }
}
