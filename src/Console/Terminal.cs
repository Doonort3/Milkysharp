#region

using System;
using System.Collections.Generic;
using System.Text;
using Milkysharp.Cli;
using Milkysharp.Core;

#endregion

namespace Milkysharp.Console
{
    public class Terminal
    {
        public static void Main()
        {
            System.Console.Clear();
            Kernel.CurrentDirectory = @$"0:\home\{Kernel.Username}\";

            System.Console.WriteLine($"Welcome to Milkysharp!" + 
                                     $"\n\nVersion ------- # {Kernel.Ver}" +
                                     $"\nShell " + $"--------- # {Kernel.ShName}" +
                                     $"\nType 'help' or 'list'.\n");

            input: if (!Kernel.CurrentDirectory.EndsWith(@"\")) Kernel.CurrentDirectory += @"\";
            // Before input like PS1 in BASH
            Methods.Write($"{Kernel.Username}", ConsoleColor.Blue);
            Methods.Write($"@{Kernel.ShName}:", ConsoleColor.White);
            Methods.Write($"[{Kernel.CurrentDirectory}]", ConsoleColor.DarkBlue);
            Methods.Write(": ", ConsoleColor.White);

            // Get input
            var input = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                var arguments = ParseCommandLine(input); // Parse arguments
                var commandName = arguments[0]; // Command name
                if (arguments.Count > 0) arguments.RemoveAt(0); // Leave only the arguments

                #region ParseCommands

                /*if (commandName.StartsWith(".\\"))
                {
                    commandName = ".\\";
                    string programName = commandName.Remove(commandName.Length - 1);
                    Commands.RunStandart(arguments, programName, commandName);
                    goto input;
                }

                if (commandName.StartsWith("."))
                {
                    commandName = ".";
                    string programName = commandName.Remove(commandName.Length - 1);
                    arguments.RemoveRange(0, 1);
                    Commands.RunStandart(arguments, programName, commandName);
                    goto input;
                }*/

                switch (commandName.Trim(' ').ToLower())
                {
                    case "clear":
                    case "cls":
                        Commands.Clear(arguments);
                        goto input;
                    case "commands":
                    case "list":
                    case "help":
                        Commands.CmdList(arguments);
                        goto input;
                    case "rtc":
                        Commands.TimeDate(arguments);
                        goto input;
                    case "pwd":
                        Commands.Pwd(arguments);
                        goto input;
                    case "mkdir":
                        Commands.Mkdir(arguments);
                        goto input;
                    case "cd":
                        Commands.Cd(arguments);
                        goto input;
                    case "ls":
                        Commands.Ls(arguments);
                        goto input;
                    case "rm":
                        Commands.Rm(arguments);
                        goto input;
                    case "cp":
                        Commands.Cp(arguments);
                        goto input;
                    case "touch":
                        Commands.Touch(arguments);
                        goto input;
                    case "mv":
                        Commands.Mv(arguments);
                        goto input;
                    case "cat":
                        Commands.Cat(arguments);
                        goto input;
                    /*case "run":
                        Commands.Run(arguments);
                        goto input;*/
                    case "poweroff":
                        Commands.AcpiShutdown(arguments);
                        goto input;
                    case "reboot":
                        Commands.CpuReboot(arguments);
                        goto input;
                    case "ver":
                    case "version":
                        Commands.Version(arguments);
                        goto input;
                    case "reconf":
                        Commands.ReConfigure(arguments);
                        goto input;
                    default:
                        Methods.WriteLine($"\"{commandName}\" not found. Use \"help\".", ConsoleColor.Red);
                        goto input;
                }

                #endregion endParseCommands
            }

            goto input;
        }

        #region Methods

        public static List<string> ParseCommandLine(string cmdLine)
        {
            var args = new List<string>();
            if (string.IsNullOrWhiteSpace(cmdLine)) return args;
            var currentArg = new StringBuilder();
            var inQuotedArg = false;
            foreach (var t in cmdLine)
                switch (t)
                {
                    case '"' when inQuotedArg:
                        args.Add(currentArg.ToString());
                        currentArg = new StringBuilder();
                        inQuotedArg = false;
                        break;
                    case '"':
                        inQuotedArg = true;
                        break;
                    case ' ' when inQuotedArg:
                        currentArg.Append(t);
                        break;
                    case ' ':
                    {
                        if (currentArg.Length > 0)
                        {
                            args.Add(currentArg.ToString());
                            currentArg = new StringBuilder();
                        }

                        break;
                    }
                    default:
                        currentArg.Append(t);
                        break;
                }

            if (currentArg.Length > 0) args.Add(currentArg.ToString());
            return args;
        }

        #endregion
    }
}