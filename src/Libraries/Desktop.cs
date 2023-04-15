#nullable enable
using System;

namespace Milkysharp.Libraries;

public class Desktop
{
    public static void Draw(ConsoleColor back, ConsoleColor fore)
    {
        System.Console.BackgroundColor = back;
        System.Console.Clear();
        System.Console.SetCursorPosition(0, 0);
        System.Console.ForegroundColor = fore;
        Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB) ...");
    }
}