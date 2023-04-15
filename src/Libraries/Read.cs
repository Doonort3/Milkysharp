#nullable enable
using System;

namespace Milkysharp.Libraries;

public class Read
{
    public static string TextBox(int maxlenght, bool showBox = true, char boxopen = '[', char boxclose = ']',
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black)
    {
        if (System.Console.CursorLeft - 80 > maxlenght + 2)
        {
            System.Console.CursorLeft = 0;
            System.Console.CursorTop++;
        }

        System.Console.BackgroundColor = back;
        System.Console.ForegroundColor = text;
        if (showBox) System.Console.Write(boxopen);
        var x = System.Console.CursorLeft;
        for (var i = 0; i <= maxlenght; i++) System.Console.Write(" ");
        if (showBox) System.Console.Write(boxclose);
        System.Console.SetCursorPosition(x, System.Console.CursorTop);
        var toreturn = "";
        if (showBox) toreturn = LootiTerminal(System.Console.CursorLeft + maxlenght + 1, ']');
        if (showBox == false) toreturn = LootiTerminal(System.Console.CursorLeft + maxlenght);
        return toreturn;
    }

    public static string LootiTerminal(int mxcurpos, char bck = ' ')
    {
        var toreturn = "";
        for (;;)
        {
            var arrow = "";
            var input = System.Console.ReadKey();
            if (input.Key == ConsoleKey.Enter) return toreturn + arrow;
            if (input.Key == ConsoleKey.Backspace)
            {
                var x = System.Console.CursorLeft;
                if (toreturn.Length != 0)
                {
                    System.Console.CursorLeft--;
                    toreturn = toreturn.Remove(toreturn.Length - 1, 1);
                    System.Console.Write(" ");
                    System.Console.CursorLeft--;
                }
                else
                {
                    System.Console.CursorLeft = x;
                }
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (toreturn.Length > 0) toreturn = toreturn.Remove(toreturn.Length - 1, 1);
            }
            else if (input.Key == ConsoleKey.RightArrow && arrow.Length > 0)
            {
                toreturn += arrow[0];
            }
            else if (input.Key == ConsoleKey.RightArrow && arrow.Length == 0)
            {
                System.Console.CursorLeft--;
            }
            else
            {
                if (System.Console.CursorLeft <= mxcurpos)
                {
                    toreturn += input.KeyChar.ToString();
                }
                else
                {
                    System.Console.CursorLeft--;
                    System.Console.Write(bck);
                    System.Console.CursorLeft--;
                }
            }
        }
    }
}