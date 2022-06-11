﻿using System;

namespace WebClient.Infrastructure.ConsoleMenu
{
    public class ConsoleHelper
    {
        public static void DisplayHeader(string text)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MsgError(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MsgMenuStepOutOrExit()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Нажмите ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Backspace");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" для возврата в основное меню.");
            Console.Write("Нажмите ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Escape");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" для выхода из программы.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MsgMenuControl()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("↓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - вниз, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("↑");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - вверх, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - вход в меню, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Escape");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" - выход из программы.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
