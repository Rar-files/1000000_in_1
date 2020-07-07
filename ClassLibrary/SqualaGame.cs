using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum Działania
    {
        Dodawanie,
        Odejmowanie,
        Mnożenie,
        Dzielenie,
        Reszta,
    }

    public static class Trudność
    {
        public const int BardzoŁatwy = 10;
        public const int Łatwy = 20;
        public const int Średni = 40;
        public const int Trudny = 80;
        public const int BardzoTrudny = 160;
    }


    public class SqualaGame
    {
        public Działania działanie { get; private set; }

        public int liczba1 { get; private set; }
        public int liczba2 { get; private set; }

        static Random Rnd = new Random();

        public SqualaGame()
        {
            działanie = RandomEnumValue<Działania>();
        }

        public void przeLosowanie(int poziom)
        {
            liczba1 = Rnd.Next(poziom / 2, poziom);
            liczba2 = Rnd.Next(poziom / 2, poziom);
        }

        public int Wynik()
        {
            int wynik = 0;
            switch (działanie)
            {
                case Działania.Dodawanie:
                    wynik = liczba1 + liczba2;
                    break;

                case Działania.Dzielenie:
                    wynik = liczba1 / liczba2;
                    break;

                case Działania.Mnożenie:
                    wynik = liczba1 * liczba2;
                    break;

                case Działania.Odejmowanie:
                    wynik = liczba1 - liczba2;
                    break;

                case Działania.Reszta:
                    wynik = liczba1 % liczba2;
                    break;
            }

            return wynik;
        }

        static private Działania RandomEnumValue<Działania>()
        {
            var v = Enum.GetValues(typeof(Działania));
            return (Działania)v.GetValue(Rnd.Next(v.Length));
        }
    }
}
