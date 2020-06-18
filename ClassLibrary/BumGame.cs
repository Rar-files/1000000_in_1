using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BumGame //Zestaw metod gry "BUM"
    {
        public static void Regulamin(int Start, int bumINT)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Witaj w grze BUM!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Zasady są proste:");
            Console.WriteLine($"1. Naprzemiennie liczymy od {Start}.");
            Console.WriteLine($"2. W momencie kiedy napotkamy liczbę zawierającą lub podzielną przez {bumINT}, zamiast liczby piszemy \"BUM\".");
            Console.WriteLine("3. Po wyświetleniu i zgaśnięciu liczby, wpisujesz następną.");
            Console.WriteLine("4. Nie ma możliwości ponownego zobaczenia liczby, trzeba ją zapamiętać i podać kolejną.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Po zapoznainu się z regulaminem naciśnij dowolny klawisz.");
            Console.ReadKey();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            if(Start%2!=0)
                Console.WriteLine("Skoro wyjaśniliśmy sobie zasady, pozwól że ja zacznę.");
            else
                Console.WriteLine("Skoro wyjaśniliśmy sobie zasady, zaczynaj!.");
            Console.WriteLine("Gotowy?");
            Console.ReadKey();
        } //Wyświetla zestaw startowych komunikatów na konsoli (Wartość będąca liczbą "BUM", Wartość Startowa)

        public static bool IfBUM(int bumINT, int test) //Zwraca "true", gdy wpisany test powinien być być BUM. (Wartość będąca liczbą "BUM", Test)
        {
            if (test % bumINT == 0) return true;

            char[] tests = test.ToString().ToCharArray();

            for(int i = 0; i<tests.Length;i++)
            {
                if(tests[i] == Convert.ToChar(bumINT.ToString())) return true;
            }

            return false;
        }

        public static string Si(int bumINT ,int correctValue, int Start)
        {
            Random nerfSi = new Random();

            int bufor = nerfSi.Next(1, 11);
            if(bufor<9)
            {
                if (BumGame.IfBUM(bumINT, correctValue)) return "BUM";
                return correctValue.ToString();
            }
            else if(bufor==10)
            {
                return nerfSi.Next(Start, correctValue+10).ToString();
            }

            if (BumGame.IfBUM(bumINT, correctValue)) return correctValue.ToString();
            return "BUM";
        } //Zwraca odpowiedź koputera, taką że nie zawsze musi być poprawna. (Wartość będąca liczbą "BUM", aktualna wartość Licznika, Wartość Startowa)
    }
}
