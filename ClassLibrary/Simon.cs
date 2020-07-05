﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace ClassLibrary
{
    public class Simon
    {
        public enum color{
            r,g,b,y
        }

        static Queue<color> simonSaid = new Queue<color>();

        static Random RndColor = new Random();
        static color RandomEnumValue<color>()
        {
            var v = Enum.GetValues(typeof(color));
            return (color)v.GetValue(RndColor.Next(v.Length));
        }

        static public void Regulamin(int n)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Witaj w grze Simon Mówi!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Zasady są proste:");
            Console.WriteLine($"1. Wyświetle Ci po kolei {n} kolorów, a twoim zadaniem będzie odtworzyć je w odpowiedniej kolejności");
            Console.WriteLine("2. Dla wygody będziemy posługiwać się nazwami kolorów po angielsku, tak abyś mógł wpisywać tylko literę.");
            Console.Write("3. Zakres kolorów: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\"r\" - Red, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\"g\" - Green, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\"b\" - Blue, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\"y\" - yellow.");
            Console.ForegroundColor = ConsoleColor.White;
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

        static public color simonSay()
        {
            color bufor;
            bufor = RandomEnumValue<color>();
            simonSaid.Enqueue(bufor);
            return bufor;
        }

        static public bool playerSaid(string test)
        {
            if (test == simonSaid.Dequeue().ToString())
                return true;
            Enum.Parse(typeof(color), test);
            return false;
        }
    }
}