using System;
using Cosmos.HAL;
using Milkysharp.Applications;
using Milkysharp.Cli;
using Milkysharp.Console;
using Milkysharp.Core;
using Milkysharp.Libraries;

namespace Milkysharp.Cui;

public static class Main
{
    public static void Start()
    {
        Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
        input:
        ConsoleKeyInfo command = System.Console.ReadKey(true);
        switch (command.Key)
        {
            case ConsoleKey.Tab:
                Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                TerminalInit();
                break;
            case ConsoleKey.R:
            {
                /*System.Console.WriteLine("Reboot PC? Y/n");
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
                }*/
                if (Box.TrueFalseBox("Power Managaer", RebootText, 20, 0, 48))
                {
                    Power.CPUReboot();
                }
                else
                {
                    Window.CloseWindows(0, 47, 23, 5, ConsoleColor.Black);
                    Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB)");
                }

                break;
            }
            case ConsoleKey.S:
            {
                /*System.Console.WriteLine("Poweroff PC? Y/n");
                string temp = System.Console.ReadLine();
                switch (Methods.ToTmp(temp).ToLower())
                {
                    case "y" or "Y":
                        Cosmos.HAL.Power.ACPIShutdown();
                        break;
                    case "n" or "N":
                        System.Console.WriteLine("Stoped.");
                        break;
                    default:
                        Cosmos.HAL.Power.ACPIShutdown();
                        break;
                }*/
                if (Box.TrueFalseBox("Power Managaer", ShutdownText, 20, 0, 33))
                {
                    Power.ACPIShutdown();
                }
                else
                {
                    Window.CloseWindows(0, 32, 23, 5, ConsoleColor.Black);
                    Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB)");
                }

                break;
            }
            case ConsoleKey.E:
            {
                Filexplorer.Init(Kernel.CurrentDirectory);
                break;
            }
            case ConsoleKey.Enter:
            {
                Window.DrawWindow("Menu", 16, 16, 0, 0, shadow: false);
                System.Console.ForegroundColor = ConsoleColor.Black;
                // Menu.StripMenu(MenuText, MenuShorts, 1, "CUI apps\n########");
                System.Console.SetCursorPosition(0, 1);
                System.Console.WriteLine("# Apps");
                System.Console.SetCursorPosition(1, 2);
                System.Console.WriteLine("Explorer");
                System.Console.SetCursorPosition(10, 2);
                System.Console.Write("[E]");
                System.Console.SetCursorPosition(1, 3);
                System.Console.WriteLine("Terminal");
                System.Console.SetCursorPosition(10, 3);
                System.Console.Write("[TAB]");
                System.Console.SetCursorPosition(0, 6);
                System.Console.WriteLine("# Hotkeys");
                System.Console.SetCursorPosition(1, 7);
                System.Console.WriteLine("Shutdown");
                System.Console.SetCursorPosition(10, 7);
                System.Console.Write("[S]");
                System.Console.SetCursorPosition(1, 8);
                System.Console.WriteLine("Reboot");
                System.Console.SetCursorPosition(10, 8);
                System.Console.Write("[R]");
                System.Console.SetCursorPosition(1, 12);
                a:
                var pressKey = System.Console.ReadKey(true);
                if (pressKey.Key == ConsoleKey.Escape)
                    Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
                else
                    goto a;
                /* Console.SetCursorPosition(x, y);
                Console.Write("Explorer");
                Console.SetCursorPosition(x + 5, y);
                Console.Write("E");
                y++;
                Console.SetCursorPosition(x, y);

                Console.Write("Terminal");
                Console.SetCursorPosition(x + 5, y);
                Console.Write("TAB");
                // y++;
                */
                break;
            }
            case ConsoleKey.Escape:
                Terminal.Main();
                break;
            default:
                goto input;
        }

        goto input;
    }

    public static void TerminalInit()
    {
        Menu.Bar("Terminal ");
        System.Console.SetCursorPosition(0, 1);
        input:
        if (!Kernel.CurrentDirectory.EndsWith(@"\")) Kernel.CurrentDirectory += @"\";
        // Before input like PS1 in BASH
        Methods.Write($"{Kernel.Username}", ConsoleColor.White);
        Methods.Write("@", ConsoleColor.Gray);
        Methods.Write($"[{Kernel.CurrentDirectory}]", ConsoleColor.White);
        Methods.Write(": ", ConsoleColor.White);

        // Get input
        var input = System.Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
        {
            var arguments = Terminal.ParseCommandLine(input); // Parse arguments
            var commandName = arguments[0]; // Command name
            if (arguments.Count > 0) arguments.RemoveAt(0); // Leave only the arguments
            switch (commandName.Trim(' ').ToLower())
            {
                case "quit":
                    Start();
                    break;
                case "test":
                    Methods.WriteLine("W: ", ConsoleColor.White);
                    string w = System.Console.ReadLine();
                    int wTrue = int.Parse(w);
                    Methods.WriteLine("Y: ", ConsoleColor.White);
                    string y = System.Console.ReadLine();
                    int yTrue = int.Parse(y);
                    Methods.WriteLine("X: ", ConsoleColor.White);
                    string x = System.Console.ReadLine();
                    int xTrue = int.Parse(x);
                    Methods.WriteLine("title: ", ConsoleColor.White);
                    string title = System.Console.ReadLine();
                    Methods.WriteLine("text: ", ConsoleColor.White);
                    string text = System.Console.ReadLine();
                    Box.MsgBox(title, text, true, wTrue, yTrue, xTrue);
                    goto input;
                default:
                    goto input;
            }
        }
    }

    #region Interface Variables

    public static string[] RebootText = { "Reboot PC?" };
    public static string[] ShutdownText = { "Shutdown PC?" };
    public static string[] MenuText = { "\nExplorer", "\nTerminal" };
    public static string[] MenuShorts = { "E", "TAB" };

    #endregion
}