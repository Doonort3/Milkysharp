#nullable enable
using System;

namespace Milkysharp.Libraries;

public class Screen
{
    public static void ClearScreen(ConsoleColor back, ConsoleColor fore)
    {
        System.Console.BackgroundColor = back;
        System.Console.Clear();
        System.Console.BackgroundColor = back;
        System.Console.SetCursorPosition(0, 0);
    }

    /*public static void Fillscreen(ConsoleColor back, ConsoleColor fore)
    {
        Console.BackgroundColor = back;
        Console.BackgroundColor = back;
        Console.SetCursorPosition(0, 0);
    }*/
}