#nullable enable
namespace Milkysharp.Libraries
{
    using System;
    public class Desktop
    {
        public static void Draw(ConsoleColor back, ConsoleColor fore)
        {
            Console.BackgroundColor = back;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = fore;
            Console.Write("Umbrella Desktop 0.1");
            Console.WriteLine("\n----------------------------");
        }
    }
}