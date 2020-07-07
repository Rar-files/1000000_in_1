using System;

using ClassLibrary;

namespace _1000000_in_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int page = 0;
            string badValue = "";

            while (true)
            {
                int parametr = rnd.Next(2, 11);

                GUI(badValue, parametr, page);
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

                catch (Exception)
                {
                    GUIend();
                }

                Console.Clear();
            }

        }

        private static void GUI(string badValue, int parametr, int page)
        {
            int parametrPage = page / 5 + 1;

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
            Console.WriteLine($"[{page + 1}] BUM - Gracze naprzemiennie liczą od {parametrPage}, w momencie gdy jakaś liczba jest podzielna/zawiera w sobie {parametr} piszą \"BUM\"");
            Console.WriteLine($"[{page + 2}] Rachmistrz - Program losuje {parametrPage} razy liczby od 1-9, a twoim zadaniem jest podać poprawną sumę.");
            Console.WriteLine($"[{page + 3}] Fundels - Gracze naprzemiennie starają się stworzyć większą liczbe składającą się z {parametrPage + 1} liczb.");
            Console.WriteLine($"[{page + 4}] Simon Mówi - Komputer tz. \"Simon\", wyświetla po koleji {parametrPage} razy kolor, a zadaniem gracza jest odtworzyć kolejność");
            Console.WriteLine($"[{page + 5}] Squala - Wykonujesz {parametrPage} działań na podanych liczbach.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (page == 0)
            {
                Console.WriteLine($"              Page {parametrPage} > ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Aby zmienić stronę wpisz \">\"");
            }
            else if (page == 200000)
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

        private static void GUIend()
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

        } //GUI zakmknięcia,
    }
}
