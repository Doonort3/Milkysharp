using Milkysharp.Cli;
using Milkysharp.Console;
using Milkysharp.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milkysharp.Cui
{
    public static class Main
    {
        public static void Start()
        {
            Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
        input:
            ConsoleKeyInfo command = System.Console.ReadKey(true);
            
            if (command.Key == ConsoleKey.Tab) 
            {
                Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                TerminalInit();
            } 
            else if (command.Key == ConsoleKey.R)
            {
                System.Console.WriteLine("Reboot PC? Y/n");
                string temp = System.Console.ReadLine();
                switch (Methods.ToTmp(temp).ToLower())
                {
                    case "y" or "Y":
                        Cosmos.HAL.Power.CPUReboot();
                        break;
                    case "n" or "N":
                        System.Console.WriteLine("Stoped.");
                        break;
                    default:
                        Cosmos.HAL.Power.CPUReboot();
                        break;
                } 
            }
            else if (command.Key == ConsoleKey.C)
            {
                System.Console.Clear();
                Terminal.Main();
            }
            else
            {
                goto input;
            }
            goto input;

        }
        public static void TerminalInit()
        {
            
            Menu.Bar("Terminal");
            System.Console.SetCursorPosition(0, 1);

        input: if (!Core.Kernel.CurrentDirectory.EndsWith(@"\")) Core.Kernel.CurrentDirectory += @"\";
            // Before input like PS1 in BASH
            Methods.Write($"{Core.Kernel.Username}", ConsoleColor.Blue);
            Methods.Write($"@{Core.Kernel.ShName}:", ConsoleColor.White);
            Methods.Write($"[{Core.Kernel.CurrentDirectory}]", ConsoleColor.DarkBlue);
            Methods.Write(": ", ConsoleColor.White);

            // Get input
            var input = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                var arguments = Console.Terminal.ParseCommandLine(input); // Parse arguments
                var commandName = arguments[0]; // Command name
                if (arguments.Count > 0) arguments.RemoveAt(0); // Leave only the arguments

                switch (commandName.Trim(' ').ToLower())
                {
                    case "quit":
                        Start();
                        break;
                    default: 
                        goto input;
                }
            }
        }
    }
}
