using System;
using System.Threading;

namespace ClassLibrary
{
    public class Rachmistrz
    {
        public static string RndNumbers { get; private set; } //Wylosowane liczby

        static public void Regulamin(int n)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Witaj w grze Rachmistrz!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Zasady są proste:");
            Console.WriteLine($"1. Wylosuje ci {n} liczb od 1-9, a twoim zadanie będzie je zsumować  podać wynik");
            Console.WriteLine("2. Liczby będą wypisywane po słowie \"start\" i na końcu pojwai się słowo \"koniec\"");
            Console.WriteLine("3. Aby łatwiej było rozróżnić, wylosowane liczby będą innym kolorem");
            Console.WriteLine("4. Każda liczba będzie odzielona przecinkiem i spacją");
            Console.WriteLine("5. W razie potrzeby przesuń konsole do góry :)");
            Console.WriteLine();
            Console.WriteLine("Gotowy?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Po zapoznainu się z regulaminem naciśnij dowolny klawisz.");
            Console.ReadKey();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Powodzenia!");
            Thread.Sleep(1000);
            Console.Clear();
        } //Regulamin Gry

        static public int Game(int n)
        {
            RndNumbers = "";
            Random rnd = new Random();
            int suma = 0;
            for(int i = 0; i<n; i++)
            {
                int bufor = rnd.Next(1, 10);
                RndNumbers += bufor + ", ";
                suma += bufor;
            }
            return suma;
        } //Wylosowuje n liczb i zapisuje je do rndNumbers oraz zwraca poprawny odpowiedź
    }
}
