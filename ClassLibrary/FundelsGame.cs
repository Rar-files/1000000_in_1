using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class FundelsGame
    {
        public static Dictionary<int, int> taliaGracz { get; private set; } = new Dictionary<int, int>();
        public static Dictionary<int, int> taliaSi { get; private set; } = new Dictionary<int, int>();

        public static void Regulamin(int n)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Witaj w grze Fundels!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Zasady są proste:");
            Console.Write("1. Na ekranie ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("różowym ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"kolorem będzie stale wypisana liczba składająca się z {n} cyfr (kart).");
            Console.WriteLine("2. Następnie wyświetlana będzie pierwsza karta z tali (talie na początku gry są tasowane)");
            Console.WriteLine("3. Zadaniem Gracza, jak i komputera będzie wybranie odpowiedniej cyfr, tak aby po wymienieniu z kartą, liczba miała większą wartość");
            Console.WriteLine("4. Cyfre do podmiany wybieramy wpisując jej id wyświetlane pod spodem.");
            Console.WriteLine("5. Ważne, żeby liczba była najmniejszą możliwą liczbą, jednak że większą od poprzedniej.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Po zapoznainu się z regulaminem naciśnij dowolny klawisz.");
            Console.ReadKey();
        } //Wyświetla zestaw startowych komunikatów na konsoli (Wartość będąca liczbą "BUM", Wartość Startowa)

        static public void InicjowanieTalli()
        {
            taliaSi.Clear();
            taliaGracz.Clear();
            int[] wartoscKarty = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < wartoscKarty.Length; j++)
                {
                    taliaGracz.Add(i * 10 + j, wartoscKarty[j]);
                    taliaSi.Add(i * 10 + j, wartoscKarty[j]);
                }
            }
        }

        static public void Tasowanie()
        {
            Random tasowanie = new Random();
            for (int i = 0; i < 100; i++)
            {
                int Id1 = tasowanie.Next(taliaGracz.Count());
                int wartosc = taliaGracz[Id1];
                int Id2 = tasowanie.Next(taliaGracz.Count());
                taliaGracz[Id1] = taliaGracz[Id2];
                taliaGracz[Id2] = wartosc;
            }
            for (int i = 0; i < 100; i++)
            {
                int Id1 = tasowanie.Next(taliaSi.Count());
                int wartosc = taliaSi[Id1];
                int Id2 = tasowanie.Next(taliaSi.Count());
                taliaSi[Id1] = taliaSi[Id2];
                taliaSi[Id2] = wartosc;
            }
        }

        static public int[] InicjowanieStolu(int n)
        {
            int[] table = new int[n];

            for(int i = 0; i<n;i++)
            {
                table[i] = 0;
            }

            return table;
        }

        static public int[] TableCards(int[] table, int test, int card)
        {
            if(Si(table,card)>test) throw new ArgumentException("Podany test nie spełnia wymagań");
            string liczba1 = null;
            for(int i = 0; i< table.Length;i++)
            {
                liczba1 = liczba1 + table[i].ToString();
            }
            string liczba2 = null;
            for (int i = 0; i < table.Length; i++)
            {
                if(i==test)
                    liczba2 = liczba2 + card.ToString();
                else
                    liczba2 = liczba2 + table[i].ToString();
            }

            if (int.Parse(liczba1) < int.Parse(liczba2))
                table[test] = card;
            else
                throw new ArgumentException("Podany test nie spełnia wymagań");

            return table;
        }

        static public int Si(int[] table, int card)
        {
            for(int i = table.Length-1; i>=0; i--)
            {
                if (table[i] < card)
                    return i;
            }
            return 0;
        }
    }
}
