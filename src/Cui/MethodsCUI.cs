#region

using System;

#endregion

namespace Milkysharp.Cui;

public class MethodsCUI
{
    public static bool isForbiddenKey(ConsoleKey key)
    {
        ConsoleKey[] forbiddenKeys =
        {
            ConsoleKey.Print, ConsoleKey.PrintScreen, ConsoleKey.Pause, ConsoleKey.Home, ConsoleKey.PageUp,
            ConsoleKey.PageDown, ConsoleKey.End, ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2,
            ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7,
            ConsoleKey.NumPad8, ConsoleKey.NumPad9, ConsoleKey.Insert, ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3,
            ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10,
            ConsoleKey.F11, ConsoleKey.F12, ConsoleKey.Add, ConsoleKey.Divide, ConsoleKey.Multiply, ConsoleKey.Subtract,
            ConsoleKey.LeftWindows, ConsoleKey.RightWindows
        };
        for (int i = 0; i < forbiddenKeys.Length; i++)
            if (key == forbiddenKeys[i])
                return true;
        return false;
    }
}