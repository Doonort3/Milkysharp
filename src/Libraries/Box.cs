#nullable enable
using System;
using System.IO;

namespace Milkysharp.Libraries;

public class Box
{
    public static void ErrorBox(string title, string[] message, int w, int y = 6, int x = 25,
        ConsoleColor back = ConsoleColor.White, ConsoleColor text = ConsoleColor.Red,
        ConsoleColor bar = ConsoleColor.Red, ConsoleColor barText = ConsoleColor.White)
    {
        w += 2;
        var oldback = System.Console.BackgroundColor;
        var oldfore = System.Console.ForegroundColor;
        System.Console.BackgroundColor = bar;
        System.Console.ForegroundColor = barText;
        System.Console.SetCursorPosition(x, y);
        for (var i = 0; i < w; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y);
        System.Console.Write("[" + title + "]");
        System.Console.BackgroundColor = back;
        System.Console.ForegroundColor = text;
        var okc = 0;
        for (var i = 0; i < message.Length + 3; i++)
        {
            System.Console.SetCursorPosition(x, y + 1 + i);
            for (var it = 0; it < w; it++) System.Console.Write(" ");
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.Write(" ");
            System.Console.BackgroundColor = back;
            okc = System.Console.CursorTop;
        }

        var yi = y + 2;
        for (var i = 0; i < message.Length; i++)
        {
            System.Console.ForegroundColor = text;
            System.Console.SetCursorPosition(x + 1, yi + i);
            if (message[i].Length <= w - 2)
                System.Console.Write(message[i]);
            else
                System.Console.Write("Msg too long");
        }

        System.Console.SetCursorPosition(x, okc);
        Menu.WriteMenuOption("OK", text);
        System.Console.SetCursorPosition(x + 5, okc);
        System.Console.SetCursorPosition(x + 1, okc + 1);
        System.Console.BackgroundColor = ConsoleColor.Black;
        for (var it = 0; it < w; it++) System.Console.Write(" ");
        System.Console.BackgroundColor = oldback;
        System.Console.ForegroundColor = oldfore;
        System.Console.SetCursorPosition(0, System.Console.CursorTop++);
        System.Console.Beep(300, 30);
    }

    public static bool TrueFalseBox(string title, string[] message, int w, int y = 6, int x = 25,
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        for (;;)
        {
            w += 2;
            var oldback = System.Console.BackgroundColor;
            var oldfore = System.Console.ForegroundColor;
            for (;;)
            {
                System.Console.BackgroundColor = bar;
                System.Console.ForegroundColor = barText;
                System.Console.SetCursorPosition(x, y);
                for (var i = 0; i < w; i++) System.Console.Write(" ");
                System.Console.SetCursorPosition(x + 1, y);
                System.Console.Write("[" + title + "]");
                System.Console.BackgroundColor = back;
                System.Console.ForegroundColor = text;
                var okc = 0;
                for (var i = 0; i < message.Length + 3; i++)
                {
                    System.Console.SetCursorPosition(x, y + 1 + i);
                    for (var it = 0; it < w; it++) System.Console.Write(" ");
                    System.Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.Write(" ");
                    System.Console.BackgroundColor = back;
                    okc = System.Console.CursorTop;
                }

                var yi = y + 2;
                for (var i = 0; i < message.Length; i++)
                {
                    System.Console.SetCursorPosition(x + 1, yi + i);
                    if (message[i].Length <= w - 2) System.Console.Write(message[i]);
                }

                System.Console.SetCursorPosition(x + 5, okc);
                Menu.WriteMenuOption("Yes", text);
                System.Console.SetCursorPosition(x + 12, okc);
                Menu.WriteMenuOption("No", text);
                System.Console.SetCursorPosition(x + 1, okc + 1);
                System.Console.BackgroundColor = ConsoleColor.Black;
                for (var it = 0; it < w; it++) System.Console.Write(" ");
                var input = System.Console.ReadKey();
                if (input.Key == ConsoleKey.Y)
                {
                    System.Console.BackgroundColor = oldback;
                    System.Console.ForegroundColor = oldfore;
                    System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                    return true;
                }

                if (input.Key == ConsoleKey.N)
                {
                    System.Console.BackgroundColor = oldback;
                    System.Console.ForegroundColor = oldfore;
                    System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                    return false;
                }

                System.Console.Beep(300, 30);
            }
        }
    }

    public static bool MsgBox(string title, string message, bool cancel, int w, int y = 12, int x = 24,
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        var Message = message.ToStringArr();
        w += 2;
        var oldback = System.Console.BackgroundColor;
        var oldfore = System.Console.ForegroundColor;
        for (;;)
        {
            System.Console.BackgroundColor = bar;
            System.Console.ForegroundColor = barText;
            System.Console.SetCursorPosition(x, y);
            for (var i = 0; i < w; i++) System.Console.Write(" ");
            System.Console.SetCursorPosition(x + 1, y);
            System.Console.Write("[" + title + "]");
            System.Console.BackgroundColor = back;
            System.Console.ForegroundColor = text;
            var okc = 0;
            for (var i = 0; i < Message.Length + 3; i++)
            {
                System.Console.SetCursorPosition(x, y + 1 + i);
                for (var it = 0; it < w; it++) System.Console.Write(" ");
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Write(" ");
                System.Console.BackgroundColor = back;
                okc = System.Console.CursorTop;
            }

            var yi = y + 2;
            for (var i = 0; i < Message.Length; i++)
            {
                System.Console.SetCursorPosition(x + 1, yi + i);
                if (Message[i].Length <= w - 2) System.Console.Write(Message[i]);
            }

            System.Console.SetCursorPosition(x + 6, okc);
            Menu.WriteMenuOption("OK", text);
            System.Console.SetCursorPosition(x + 13, okc);
            if (cancel) Menu.WriteMenuOption("CANCEL", text);
            System.Console.SetCursorPosition(x + 1, okc + 1);
            System.Console.BackgroundColor = ConsoleColor.Black;
            for (var it = 0; it < w; it++) System.Console.Write(" ");
            var input = System.Console.ReadKey(true);
            if (input.Key == ConsoleKey.O)
            {
                System.Console.BackgroundColor = oldback;
                System.Console.ForegroundColor = oldfore;
                System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                return true;
            }

            if (input.Key == ConsoleKey.C && cancel)
            {
                System.Console.BackgroundColor = oldback;
                System.Console.ForegroundColor = oldfore;
                System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                return false;
            }

            System.Console.Beep(300, 30);
        }
    }

    public static bool ArrBox(string title, string[] message, bool cancel, int w, int y = 6, int x = 25,
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        w += 2;
        var oldback = System.Console.BackgroundColor;
        var oldfore = System.Console.ForegroundColor;
        for (;;)
        {
            System.Console.BackgroundColor = bar;
            System.Console.ForegroundColor = barText;
            System.Console.SetCursorPosition(x, y);
            for (var i = 0; i < w; i++) System.Console.Write(" ");
            System.Console.SetCursorPosition(x + 1, y);
            System.Console.Write("[" + title + "]");
            System.Console.BackgroundColor = back;
            System.Console.ForegroundColor = text;
            var okc = 0;
            for (var i = 0; i < message.Length + 3; i++)
            {
                System.Console.SetCursorPosition(x, y + 1 + i);
                for (var it = 0; it < w; it++) System.Console.Write(" ");
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Write(" ");
                System.Console.BackgroundColor = back;
                okc = System.Console.CursorTop;
            }

            var yi = y + 2;
            for (var i = 0; i < message.Length; i++)
            {
                System.Console.SetCursorPosition(x + 1, yi + i);
                if (message[i].Length <= w - 2) System.Console.Write(message[i]);
            }

            System.Console.SetCursorPosition(x + 6, okc);
            Menu.WriteMenuOption("OK", text);
            System.Console.SetCursorPosition(x + 13, okc);
            if (cancel) Menu.WriteMenuOption("CANCEL", text);
            System.Console.SetCursorPosition(x + 1, okc + 1);
            System.Console.BackgroundColor = ConsoleColor.Black;
            for (var it = 0; it < w; it++) System.Console.Write(" ");
            var input = System.Console.ReadKey();
            if (input.Key == ConsoleKey.O)
            {
                System.Console.BackgroundColor = oldback;
                System.Console.ForegroundColor = oldfore;
                System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                return true;
            }

            if (input.Key == ConsoleKey.C && cancel)
            {
                System.Console.BackgroundColor = oldback;
                System.Console.ForegroundColor = oldfore;
                System.Console.SetCursorPosition(0, System.Console.CursorTop++);
                return false;
            }

            System.Console.Beep(300, 30);
        }
    }

    public static string OpenBox(string? path, string title = "Open", string message = "File to open", int w = 32,
        int y = 6, int x = 25, ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        string[] files = { " ", " " };
        if (Directory.Exists(path)) files = Directory.GetFiles(path);
        System.Console.SetCursorPosition(x, y);
        System.Console.BackgroundColor = bar;
        System.Console.ForegroundColor = barText;
        for (var i = 0; i < w; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y);
        System.Console.Write("[" + title + "]");
        var okc = 0;
        for (var i = 0; i < files.Length + 5; i++)
        {
            System.Console.BackgroundColor = back;
            System.Console.SetCursorPosition(x, y + 1 + i);
            for (var it = 0; it < w; it++) System.Console.Write(" ");
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.Write(" ");
            System.Console.BackgroundColor = back;
            okc = System.Console.CursorTop;
        }

        System.Console.SetCursorPosition(x + 1, okc + 1);
        System.Console.BackgroundColor = ConsoleColor.Black;
        for (var it = 0; it < w; it++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y + 2);
        System.Console.BackgroundColor = back;
        System.Console.ForegroundColor = text;
        System.Console.Write("[" + message + "]");
        for (var i = 0; i < files.Length; i++)
        {
            System.Console.SetCursorPosition(x + 1, y + 3 + i);
            System.Console.Write(files[i]);
            System.Console.SetCursorPosition(x + 1, y + 4 + i);
        }

        System.Console.CursorTop++;
        System.Console.Write(title + ": [");
        var h = System.Console.CursorLeft;
        System.Console.CursorLeft += w - 10;
        var mxcurpos = System.Console.CursorLeft;
        System.Console.Write("]");
        System.Console.CursorLeft = h;
        var opn = Read.LootiTerminal(mxcurpos, ']');
        return opn;
    }

    public static string InputBox(string title, string print, int y = 6, int x = 25,
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        System.Console.BackgroundColor = bar;
        System.Console.ForegroundColor = barText;
        System.Console.SetCursorPosition(x, y);
        for (var i = 0; i < 35; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x, y);
        System.Console.Write(" [" + title + "]");
        System.Console.ForegroundColor = text;
        System.Console.BackgroundColor = back;
        System.Console.SetCursorPosition(x, y + 1);
        for (var i = 0; i < 35; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x, y + 2);
        for (var i = 0; i < 35; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y + 2);
        System.Console.Write(print + ": [");
        var x2 = System.Console.CursorLeft;
        System.Console.SetCursorPosition(x + 33, y + 2);
        System.Console.Write("]");
        var x3 = System.Console.CursorLeft + 1;
        System.Console.SetCursorPosition(x, y + 3);
        for (var i = 0; i < 35; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x + 1, y + 4);
        System.Console.BackgroundColor = ConsoleColor.Black;
        for (var i = 0; i < 35; i++) System.Console.Write(" ");
        System.Console.SetCursorPosition(x3, y + 1);
        System.Console.Write(" ");
        System.Console.SetCursorPosition(x3, y + 2);
        System.Console.Write(" ");
        System.Console.SetCursorPosition(x3, y + 3);
        System.Console.Write(" ");
        System.Console.BackgroundColor = ConsoleColor.Gray;
        System.Console.SetCursorPosition(x2, y + 2);
        var toret = Read.LootiTerminal(x + 33, ']');
        return toret;
    }

    public static string[] Login(string login, string password, int y = 6, int x = 25,
        ConsoleColor back = ConsoleColor.Gray, ConsoleColor text = ConsoleColor.Black,
        ConsoleColor bar = ConsoleColor.Blue, ConsoleColor barText = ConsoleColor.White)
    {
        System.Console.BackgroundColor = ConsoleColor.Black;
        System.Console.Clear();
        var logInput = InputBox("Login", "Login", y, x, back, text, bar, barText);
        var passInput = InputBox("Login", "Password", y, x, back, text, bar, barText);
        var toret = new string[2];
        toret[0] = logInput;
        toret[1] = passInput;
        if (toret[0] != login || toret[1] != password)
        {
            MsgBox("Login", "Incorrect login or password,\ntry again", false, 30);
            Login(login, password, x: 20, y: 10);
        }

        return toret;
    }
}