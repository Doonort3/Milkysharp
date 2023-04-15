#nullable enable
using System;

namespace Milkysharp.Libraries;

public class Menu
{
    public static void WriteMenuOption(string text, ConsoleColor fore = ConsoleColor.Black)
    {
        System.Console.ForegroundColor = fore;
        System.Console.Write("[");
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.Write(text[0]);
        System.Console.ForegroundColor = fore;
        System.Console.Write(text.Remove(0, 1));
        System.Console.Write("]");
    }

    public static void Bar(string text, int x = 0, int y = 0)
    {
        var old = System.Console.BackgroundColor;
        System.Console.BackgroundColor = ConsoleColor.Blue;
        System.Console.SetCursorPosition(x, y);
        for (var i = 0; i < 80; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x, y);
        System.Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine(text);

        System.Console.BackgroundColor = old;
    }

    public static char StripMenu(string[] text, string[] shorts, int x, string name)
    {
        System.Console.BackgroundColor = ConsoleColor.Gray;
        System.Console.ForegroundColor = ConsoleColor.Black;
        var y = 1;
        System.Console.SetCursorPosition(x, y);
        for (var it = 0; it != 11; it++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x, y);
        System.Console.Write(name);
        for (var i = 0; i != text.Length; i++)
        {
            y++;
            System.Console.SetCursorPosition(x, y);
            for (var it = 0; it != 10; it++) System.Console.Write(" ");
            System.Console.ForegroundColor = ConsoleColor.Black;
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(text[i]);
            System.Console.SetCursorPosition(x + 10, y);
            System.Console.Write(shorts[i]);
        }

        return System.Console.ReadKey().KeyChar;
    }
}