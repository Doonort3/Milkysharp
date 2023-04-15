#nullable enable
using System;

namespace Milkysharp.Libraries;

public class Window
{
    public static int[] DrawWindow(string title, int w = 62, int h = 12, int x = 2, int y = 2,
        bool showtitlebrackets = true, bool shadow = true, ConsoleColor back = ConsoleColor.Gray,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        System.Console.SetCursorPosition(x, y);
        System.Console.BackgroundColor = bar;
        System.Console.ForegroundColor = barText;
        for (var i = 0; i < w; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y);
        if (showtitlebrackets)
            System.Console.Write("[" + title + "]");
        else
            System.Console.Write(title);
        System.Console.SetCursorPosition(x, y + 1);
        var mxX = 0;
        for (var i = 0; i < h; i++)
        {
            System.Console.BackgroundColor = back;
            System.Console.SetCursorPosition(x, y + 1 + i);
            for (var ii = 0; ii < w; ii++) System.Console.Write(" ");
            mxX = System.Console.CursorLeft;
            if (shadow)
            {
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Write(" ");
            }
        }

        var mxY = System.Console.CursorTop;
        System.Console.CursorLeft = x + 1;
        System.Console.CursorTop++;
        if (shadow)
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            for (var i = 0; i < w; i++) System.Console.Write(" ");
        }

        System.Console.BackgroundColor = back;
        System.Console.SetCursorPosition(x + 1, y + 1);
        int[] ret = { mxX, mxY };
        return ret;
    }

    public static int[] CloseWindows(int y, int x, int w, int h, ConsoleColor back)
    {
        System.Console.SetCursorPosition(x, y);

        System.Console.SetCursorPosition(x, y);
        for (var i = 0; i < w; i++) System.Console.Write(" ");
        var mxX = 0;
        for (var i = 0; i < h; i++)
        {
            System.Console.BackgroundColor = back;
            System.Console.SetCursorPosition(x, y + 1 + i);
            for (var ii = 0; ii < w; ii++) System.Console.Write(" ");
            mxX = System.Console.CursorLeft;
        }

        var mxY = System.Console.CursorTop;
        System.Console.CursorLeft = x + 1;
        System.Console.CursorTop++;

        System.Console.BackgroundColor = back;
        System.Console.SetCursorPosition(x + 1, y + 1);
        int[] ret = { mxX, mxY };
        return ret;
    }
}