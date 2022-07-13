#region

using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.HAL;
using Milkysharp.Applications;
using Milkysharp.Cli;
using Milkysharp.Core;
using Milkysharp.Other;

#endregion

namespace Milkysharp.Console
{
    internal class Commands
    {
        #region Execute

        /*public static void Run(List<string> arguments)
        {
            if (arguments.Count == 1 && arguments[0].ToLower() is "--help" or "-h")
            {
                Methods.Help("{program}", @"$ run {program}", "Running a program embedded in the system, or an external .BIN");
            }
            else if (arguments.Count > 1 && (arguments[0].ToLower() is "-h" or "--help"))
            {
                Methods.WriteLine("Syntax error. Use \"run --help (-h)\" command.", ConsoleColor.Red);
            }
            else if (arguments.Count == 1 && (arguments[0].ToLower() is not "-h" or "--help"))
            {
                if (arguments[0].StartsWith("\\"))
                {
                    if (arguments[0].ToUpper().EndsWith(".BIN"))
                    {
                        try
                        {
                            Methods.WriteLine("Execute files are currently not supported.", ConsoleColor.Yellow);
                            byte[] data = File.ReadAllBytes(Kernel.CurrentDirectory + arguments[0]);
                            Runner.Reset(true);
                            Memory.WriteArray(0, data, data.Length);
                            Runner.Start();
                        }
                        catch
                        {
                            Methods.WriteLine("Program launch error.", ConsoleColor.Red);
                        }
                    }
                    else if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                    {
                        string fileName = Path.GetFileName(Kernel.CurrentVolume + arguments[0]);
                        if (fileName == "miv.prg")
                        {
                            if (arguments.Count == 2 && arguments[1].ToLower() is "--help" or "-h")
                            {
                                Methods.Help("{file name}", @"$ run MIV.BPR {file name}", "Starting the MIV text editor.");
                            }
                            else if (arguments.Count > 1 && (arguments[0].ToLower() is "-h" or "--help"))
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                            else if (arguments.Count == 2 && arguments[0].ToLower() is not "--help" or "-h")
                            {
                                MIV.StartMIV(arguments);
                            }
                            else if (arguments.Count == 0)
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                            else
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            Methods.WriteLine(fileName + " not found.", ConsoleColor.Red);
                        }

                    }
                    else if (!File.Exists(Kernel.CurrentVolume + arguments[1].ToUpper()))
                    {
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                    else if (arguments.Count == 0)
                    {
                        Methods.WriteLine("Syntax error. Use \"rtc --help (-h)\" command.", ConsoleColor.Red);
                    }
                }
                else if (!arguments[0].StartsWith("\\"))
                {
                    if (arguments[0].ToUpper().EndsWith(".BIN"))
                    {
                        try
                        {
                            Methods.WriteLine("Execute files are currently not supported.", ConsoleColor.Yellow);
                            byte[] data = File.ReadAllBytes(Kernel.CurrentDirectory + arguments[0]);
                            Runner.Reset(true);
                            Memory.WriteArray(0, data, data.Length);
                            Runner.Start();
                        }
                        catch
                        {
                            Methods.WriteLine("Program launch error.", ConsoleColor.Red);
                        }
                    }
                    else if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                    {
                        string fileName = Path.GetFileName(Kernel.CurrentDirectory + arguments[0]);
                        if (fileName == "miv.prg")
                        {
                            if (arguments.Count == 2 && arguments[1].ToLower() is "--help" or "-h")
                            {
                                Methods.Help("{file name}", @"$ run MIV.BPR {file name}", "Starting the MIV text editor.");
                            }
                            else if (arguments.Count > 1 && (arguments[0].ToLower() is "-h" or "--help"))
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                            else if (arguments.Count == 2 && arguments[0].ToLower() is not "--help" or "-h")
                            {
                                MIV.StartMIV(arguments);
                            }
                            else if (arguments.Count == 0)
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                            else
                            {
                                Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            Methods.WriteLine(fileName + " not found.", ConsoleColor.Red);
                        }

                    }
                    else if (!File.Exists(Kernel.CurrentDirectory + arguments[1].ToUpper()))
                    {
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                    else if (arguments.Count == 0)
                    {
                        Methods.WriteLine("Syntax error. Use \"rtc --help (-h)\" command.", ConsoleColor.Red);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Kernel panic!");
                    Console.ReadKey();
                    Cosmos.HAL.Power.ACPIReboot();
                }
            }
            else if (arguments.Count == 0)
            {
                Methods.WriteLine("Syntax error. Use \"run --help (-h)\" command.", ConsoleColor.Red);
            }
        }*/

        public static void RunStandart(List<string> arguments, string progName, string commandName)
        {
            if (commandName == ".\\")
            {
                if (progName.EndsWith(".bin"))
                {
                    try
                    {
                        Methods.WriteLine("Execute files are currently not supported.", ConsoleColor.Yellow);
                        /*byte[] data = File.ReadAllBytes(Kernel.CurrentDirectory + arguments[0]);
                        Runner.Reset(true);
                        Memory.WriteArray(0, data, data.Length);
                        Runner.Start();*/
                    }
                    catch
                    {
                        Methods.WriteLine("Program launch error.", ConsoleColor.Red);
                    }
                }
                else if (progName.EndsWith(".prg"))
                {
                    var fileName = Path.GetFileName(Kernel.CurrentVolume + progName);
                    if (fileName == "miv.prg")
                    {
                        if (arguments.Count == 2 && arguments[1].ToLower() is "--help" or "-h")
                            Methods.Help("{file name}", @"$ run MIV.BPR {file name}", "Starting the MIV text editor.");
                        else if (arguments.Count > 1 && arguments[0].ToLower() is "-h" or "--help")
                            Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.",
                                ConsoleColor.Red);
                        else if (arguments.Count == 2 && arguments[0].ToLower() is not "--help" or "-h")
                            MIVMain.StartMIV(arguments[0]);
                        else if (arguments.Count == 0)
                            Methods.WriteLine(@"Syntax error. Use  '.\bin\miv.prg --help (-h)\' command.",
                                ConsoleColor.Red);
                        else
                            Methods.WriteLine(@"Syntax error. Use  '.\bin\miv.prg --help (-h)\' command.",
                                ConsoleColor.Red);
                    }
                    else
                    {
                        Methods.WriteLine(fileName + " not found.", ConsoleColor.Red);
                    }

                    if (!File.Exists(Kernel.CurrentVolume + fileName.ToUpper()))
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                }
            }
            else if (commandName == ".")
            {
                if (progName.EndsWith(".bin"))
                {
                    try
                    {
                        Methods.WriteLine("Execute files are currently not supported.", ConsoleColor.Yellow);
                        /*byte[] data = File.ReadAllBytes(Kernel.CurrentDirectory + arguments[0]);
                        Runner.Reset(true);
                        Memory.WriteArray(0, data, data.Length);
                        Runner.Start();*/
                    }
                    catch
                    {
                        Methods.WriteLine("Program launch error.", ConsoleColor.Red);
                    }
                }
                else if (progName.EndsWith(".prg"))
                {
                    var fileName = Path.GetFileName(Kernel.CurrentDirectory + progName);
                    if (fileName == "miv.prg")
                    {
                        if (arguments.Count == 2 && arguments[1].ToLower() is "--help" or "-h")
                            Methods.Help("{file name}", @"$ run MIV.BPR {file name}", "Starting the MIV text editor.");
                        else if (arguments.Count > 1 && arguments[0].ToLower() is "-h" or "--help")
                            Methods.WriteLine("Syntax error. Use \"run MIV.BPR --help (-h)\" command.",
                                ConsoleColor.Red);
                        else if (arguments.Count == 2 && arguments[0].ToLower() is not "--help" or "-h")
                            MIVMain.StartMIV(arguments[0]);
                        else if (arguments.Count == 0)
                            Methods.WriteLine(@"Syntax error. Use  '.miv.prg --help (-h)\' command.", ConsoleColor.Red);
                        else
                            Methods.WriteLine(@"Syntax error. Use  '.miv.prg --help (-h)\' command.", ConsoleColor.Red);
                    }
                    else
                    {
                        Methods.WriteLine(fileName + " not found.", ConsoleColor.Red);
                    }

                    if (!File.Exists(Kernel.CurrentDirectory + fileName.ToUpper()))
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                }
            }
            else if (arguments.Count == 0)
            {
                Methods.WriteLine("Syntax error.", ConsoleColor.Red);
            }
        }

        #endregion endExecute

        #region Basic

        public static void Clear(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("null", @"$ clear\$ cls", "Clearing the terminal screen.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"clear (cls) --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                    System.Console.Clear();
                    break;
                case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                    Methods.WriteLine("Syntax error. Use \"clear (cls) --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void CmdList(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("null", "$ cmdlist", "A list of all the commands.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"cmdlist --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                {
                    string[] commands =
                    {
                        "\nCMD: cls\\clear ---------------- DESC: Clearing the terminal screen.",
                        "CMD: pwd ---------------------- DESC: Display the current directory.",
                        "CMD: mkdir -------------------- DESC: Creating a new folder.",
                        "CMD: cd ----------------------- DESC: Changing the working directory.",
                        "CMD: ls ----------------------- DESC: Display all folders and files.",
                        "CMD: rm ----------------------- DESC: Deleting file or a directory.",
                        "CMD: cp ----------------------- DESC: Copies the file to the spec. folder.",
                        "CMD: touch -------------------- DESC: Create a file.",
                        "CMD: mv ----------------------- DESC: Move the file.",
                        "CMD: cat ---------------------- DESC: Read all lines of text.",
                        "CMD: poweroff ----------------- DESC: Turn off the computer.",
                        "CMD: reboot ------------------- DESC: Reboot the computer.",
                        // "CMD: run ---------------------- DESC: Running a program.",
                        "CMD: reconf ------------------- DESC: Re-check the entire system.\n"
                    };
                    foreach (var command in commands) System.Console.WriteLine($"{command}");
                    System.Console.WriteLine(
                        "To output a detailed command description, type \"commandName -h or --help\" " +
                        "\neg. \"mkdir -h\"");
                    break;
                }
            }
        }

        public static void Version(List<string> arguments)
        {
            System.Console.WriteLine($"\nSystem ------- # {Kernel.Ver} {Kernel.OsName}" +
                                     $"\nShell -------- # {Kernel.ShVer} {Kernel.ShName}" +
                                     $"\nUser Kit ----- # {Kernel.UserKitVer}\n");
        }

        #endregion endBasic

        #region VFS

        public static void Pwd(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("null", "$ pwd", "Display the current directory.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"pwd --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                    System.Console.WriteLine(Kernel.CurrentDirectory);
                    break;
                case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                    Methods.WriteLine("Syntax error. Use \"pwd --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Mkdir(List<string> arguments)
        {
            var dirName = arguments[0];
            switch (arguments.Count)
            {
                case 0:
                    Methods.WriteLine("Syntax error. Use \"mkdir --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("{folder name}", "$ mkdir {folder name}",
                        "Creating a new folder in the current directory.");
                    break;
                case > 1:
                    Methods.WriteLine("Syntax error. Use \"mkdir --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 1 when arguments[0].ToLower() is not "-h" or "--help":
                {
                    if (arguments[0].StartsWith("\\"))
                    {
                        if (!Directory.Exists(Kernel.CurrentVolume + dirName))
                        {
                            if (!dirName.Contains('.') && !dirName.Contains("/") && !dirName.Contains(':') &&
                                !dirName.Contains('*') && !dirName.Contains('?') && !dirName.Contains('<') &&
                                !dirName.Contains('>') && !dirName.Contains('|') && !dirName.Contains('+') &&
                                !dirName.Contains(' ')) Directory.CreateDirectory(Kernel.CurrentVolume + dirName);
                            else
                                System.Console.WriteLine("The following characters are prohibited " +
                                                                 "in the names of folders and files:\n" +
                                                                 @"'-' '.' '/' ':' '*' '?' '<' '>' '|' '+' space (' ')");
                        }
                        else
                        {
                            Methods.WriteLine("Directory already exist.", ConsoleColor.Yellow);
                        }
                    }
                    else if (!arguments[0].StartsWith("\\"))
                    {
                        if (!Directory.Exists(Kernel.CurrentDirectory + dirName))
                        {
                            if (!dirName.Contains('.') && !dirName.Contains(@"\") && !dirName.Contains("/") &&
                                !dirName.Contains(':') && !dirName.Contains('*') && !dirName.Contains('?') &&
                                !dirName.Contains('<') && !dirName.Contains('>') && !dirName.Contains('|') &&
                                !dirName.Contains('+') && !dirName.Contains(' '))
                                Directory.CreateDirectory(Kernel.CurrentDirectory + dirName);
                            else
                                System.Console.WriteLine("The following characters are prohibited " +
                                                                 "in the names of folders and files:\n" +
                                                                 @"'-' '.' '\' '/' ':' '*' '?' '<' '>' '|' '+' space (' ')");
                        }
                        else
                        {
                            Methods.WriteLine("Directory already exist.", ConsoleColor.Yellow);
                        }
                    }
                    else if (arguments.Count > 1)
                    {
                        Methods.WriteLine("Syntax error. Use \"mkdir --help (-h)\" command.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
            }
        }

        public static void Cd(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("{directory}", "$ cd {directory}", "Changing the working directory.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                case 0:
                    Methods.WriteLine("Syntax error. Use \"cd --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                {
                    var dir = arguments[0];
                    if (arguments.Count > 0 && dir is "..")
                    {
                        if (Kernel.CurrentDirectory == @"0:\" && Kernel.CurrentDirectory == @"0:\\")
                        {
                            System.Console.WriteLine();
                        }
                        else
                        {
                            Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                            var root = Kernel.Vfs.GetDirectory(Kernel.CurrentDirectory);
                            if (Kernel.CurrentDirectory != Kernel.CurrentVolume)
                                Kernel.CurrentDirectory = root.mParent.mFullPath + @"\";
                        }
                    }
                    else if (dir == @"\home")
                    {
                        Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                        Kernel.CurrentDirectory = Kernel.CurrentVolume + @"home\" + Kernel.Username + @"\";
                    }
                    else if (dir == Kernel.CurrentVolume)
                    {
                        Kernel.CurrentDirectory = Kernel.CurrentVolume;
                    }
                    else if (dir.StartsWith("\\"))
                    {
                        if (Directory.Exists(Kernel.CurrentVolume + dir))
                        {
                            Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                            Kernel.CurrentDirectory = Kernel.CurrentVolume + dir + @"\";
                        }
                        else if (File.Exists(Kernel.CurrentVolume + dir))
                        {
                            Methods.WriteLine("ERROR: This is a file.", ConsoleColor.Red);
                        }
                        else
                        {
                            Methods.WriteLine("ERROR: Directory doesn't exist.", ConsoleColor.Red);
                        }
                    }
                    else if (!dir.StartsWith("\\"))
                    {
                        if (Directory.Exists(Kernel.CurrentDirectory + dir))
                        {
                            Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                            Kernel.CurrentDirectory = Kernel.CurrentDirectory + dir + @"\";
                        }
                        else if (File.Exists(Kernel.CurrentDirectory + dir))
                        {
                            Methods.WriteLine("ERROR: This is a file.", ConsoleColor.Red);
                        }
                        else
                        {
                            Methods.WriteLine("ERROR: Directory doesn't exist.", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
            }
        }

        public static void Ls(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("null", "$ ls", "Display all folders and files in the current directory.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"ls --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                {
                    var dir = Kernel.CurrentDirectory;
                    foreach (var dirs in Directory.GetDirectories(dir)) System.Console.WriteLine(dirs);
                    foreach (var files in Directory.GetFiles(dir)) System.Console.WriteLine(files);
                    break;
                }
                case > 0:
                    Methods.WriteLine("Syntax error. Use \"ls --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Rm(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("-r, {folder}, {file}", @"$ rm {arg if need} {folder\file}",
                        "Deleting files (without args) or a directory with all its contents. (-r arg).");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"rm --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case > 1 when arguments[0] is "-r":
                {
                    if (arguments[1].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentVolume + arguments[1]))
                            Methods.WriteLine("ERROR: This is a file.", ConsoleColor.Red);
                        else if (Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                            Directory.Delete(Kernel.CurrentVolume + arguments[1], true);
                        else if (!Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                            Methods.WriteLine("ERROR: This directory doesn't exist.", ConsoleColor.Red);
                    }
                    else if (!arguments[1].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentDirectory + arguments[1]))
                            Methods.WriteLine("ERROR: This is a file.", ConsoleColor.Red);
                        else if (Directory.Exists(Kernel.CurrentDirectory + arguments[1]))
                            Directory.Delete(Kernel.CurrentDirectory + arguments[1], true);
                        else if (!Directory.Exists(Kernel.CurrentDirectory + arguments[1]))
                            Methods.WriteLine("ERROR: This directory doesn't exist.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case > 0 when arguments[0].ToLower() is not "-r" or "--help" or "-h":
                {
                    if (arguments[0].StartsWith("\\"))
                    {
                        if (Directory.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("ERROR: This is a folder.", ConsoleColor.Red);
                        else if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            File.Delete(Kernel.CurrentVolume + arguments[0]);
                        else if (!File.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("ERROR: This file doesn't exist.", ConsoleColor.Red);
                    }
                    else if (!arguments[0].StartsWith("\\"))
                    {
                        if (Directory.Exists(@"0:\" + arguments[0]))
                            Methods.WriteLine("ERROR: This is a folder.", ConsoleColor.Red);
                        else if (File.Exists(@"0:\" + arguments[0])) File.Delete(@"0:\" + arguments[0]);
                        else if (!File.Exists(@"0:\" + arguments[0]))
                            Methods.WriteLine("ERROR: This file doesn't exist.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case 1 when arguments[0] is "-r":
                case 0:
                    Methods.WriteLine("Syntax error. Use \"rm --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Cp(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("{full path file}, {dir}", @"$ cp {file to copy} {dir}",
                        "Copies the file to the specified folder.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"cp --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 2 when arguments[0].ToLower() is not "-h" or "--help":
                {
                    if (arguments[0].StartsWith("\\") && arguments[1].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentVolume + arguments[0]) &&
                            Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                            File.Copy(Kernel.CurrentVolume + arguments[0], Kernel.CurrentVolume + arguments[1], true);
                        else if (!File.Exists(Kernel.CurrentVolume + arguments[0]) &&
                                 !Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                            Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                    }
                    else if (!arguments[0].StartsWith("\\") && !arguments[1].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentDirectory + arguments[0]) &&
                            Directory.Exists(Kernel.CurrentDirectory + arguments[1]))
                            File.Copy(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1],
                                true);
                        else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]) &&
                                 !Directory.Exists(Kernel.CurrentDirectory + arguments[1]))
                            Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case 0:
                    Methods.WriteLine("Syntax error. Use \"cp --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Touch(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("{full path file}", @"$ touch {file}", "Create a new file in current directory.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"touch --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 1 when arguments[0].ToLower() is not "--help" or "-h":
                {
                    if (arguments[0].StartsWith("\\"))
                    {
                        if (!File.Exists(Kernel.CurrentVolume + arguments[0]))
                            try
                            {
                                File.Create(Kernel.CurrentVolume + arguments[0]);
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in creating the file.", ConsoleColor.Red);
                            }
                        else if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("ERROR: File already exist.", ConsoleColor.Red);
                    }
                    else if (!arguments[0].StartsWith("\\"))
                    {
                        if (!File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            try
                            {
                                File.Create(Kernel.CurrentDirectory + arguments[0]);
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in creating the file.", ConsoleColor.Red);
                            }
                        else if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            Methods.WriteLine("ERROR: File already exist.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case 2:
                case 0:
                    Methods.WriteLine("Syntax error. Use \"touch --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Mv(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("{path}, {dir}", @"$ mv {file} {dir}", "Move the file to the specified folder.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"mv --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 2 when arguments[0].ToLower() is not "-h" or "--help":
                {
                    if (arguments[0].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            try
                            {
                                File.Copy(Kernel.CurrentVolume + arguments[0], Kernel.CurrentVolume + arguments[1],
                                    true);
                                File.Delete(Kernel.CurrentVolume + arguments[0]);
                                // File.Move(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1]);
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in moving the file.", ConsoleColor.Red);
                            }
                        else if (!File.Exists(@"0:\" + arguments[0]) && !Directory.Exists(@"0:\" + arguments[1]))
                            Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                    }
                    else if (!arguments[0].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            try
                            {
                                File.Copy(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentVolume + arguments[1],
                                    true);
                                File.Delete(Kernel.CurrentDirectory + arguments[0]);
                                // File.Move(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1]);
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in moving the file.", ConsoleColor.Red);
                            }
                        else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]) &&
                                 !Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                            Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case 0:
                    Methods.WriteLine("Syntax error. Use \"mv --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void Cat(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("{file}", @"$ cat {file}", "Read all lines of text in the specified file.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"cat --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 1 when arguments[0].ToLower() is not "-h" or "--help":
                {
                    if (arguments[0].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            try
                            {
                                var text = File.ReadAllText(Kernel.CurrentVolume + arguments[0]);
                                System.Console.WriteLine(Methods.ToTmp(text));
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in reading the file.", ConsoleColor.Red);
                            }
                        else if (!File.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                    else if (!arguments[0].StartsWith("\\"))
                    {
                        if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            try
                            {
                                var text = File.ReadAllText(Kernel.CurrentDirectory + arguments[0]);
                                System.Console.WriteLine(Methods.ToTmp(text));
                            }
                            catch
                            {
                                Methods.WriteLine("There was an unknown error in reading the file.", ConsoleColor.Red);
                            }
                        else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                    else
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }

                    break;
                }
                case 0:
                    Methods.WriteLine("Syntax error. Use \"cat --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void TimeDate(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("-r, -t", @"$ rtc (-t, -d)", "RTC date or time output.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"rtc --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 1 when arguments[0].ToLower() is "-t":
                    System.Console.WriteLine(Rtc.GetTime());
                    break;
                case 1 when arguments[0].ToLower() is "-d":
                    System.Console.WriteLine(Rtc.GetDateFormatted());
                    break;
                case 0:
                    Methods.WriteLine("Syntax error. Use \"rtc --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        #endregion endVFS

        #region System

        public static void AcpiShutdown(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("null", "$ poweroff", "Turn off the computer.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"poweroff --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                {
                    Methods.WriteLine(@"Turn off your computer? Y\n", ConsoleColor.Yellow);
                    var temp = System.Console.ReadLine();
                    switch (Methods.ToTmp(temp).ToLower())
                    {
                        case "y" or "yes":
                            System.Console.Clear();
                            Power.ACPIShutdown();
                            break;
                        case "n" or "no":
                            System.Console.WriteLine("Stoped.");
                            break;
                        default:
                            System.Console.Clear();
                            System.Console.WriteLine("Auto. Power off... ");
                            Power.ACPIShutdown();
                            break;
                    }

                    File.Delete(@"0:\var\tmp\temp.tmp");
                    break;
                }
                case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                    Methods.WriteLine("Syntax error. Use \"pwd --help (-h)\" command.", ConsoleColor.Red);
                    break;
            }
        }

        public static void CpuReboot(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.Help("null", "$ reboot", "Reboot the computer.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"reboot --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                {
                    Methods.WriteLine(@"Reboot your computer? Y\n", ConsoleColor.Yellow);
                    var temp = System.Console.ReadLine();
                    switch (Methods.ToTmp(temp).ToLower())
                    {
                        case "y" or "yes":
                            System.Console.Clear();
                            Power.CPUReboot();
                            break;
                        case "n" or "no":
                            System.Console.WriteLine("Stoped.");
                            break;
                        default:
                            System.Console.Clear();
                            System.Console.WriteLine("Auto. Power off... ");
                            Power.CPUReboot();
                            break;
                    }

                    File.Delete(@"0:\var\tmp\temp.tmp");
                    break;
                }
            }
        }

        public static void ReConfigure(List<string> arguments)
        {
            switch (arguments.Count)
            {
                case 1 when arguments[0].ToLower() is "--help" or "-h":
                    Methods.Help("null", @"$ reconf", "Re-check the entire system and troubleshoot, if detected.");
                    break;
                case > 1 when arguments[0].ToLower() is "-h" or "--help":
                    Methods.WriteLine("Syntax error. Use \"reconf --help (-h)\" command.", ConsoleColor.Red);
                    break;
                case 0:
                {
                    Methods.WriteLine(@"Re-check the entire system? y\N", ConsoleColor.Yellow);
                    System.Console.Write("> ");
                    var temp = System.Console.ReadLine();
                    switch (Methods.ToTmp(temp).ToLower())
                    {
                        case "y" or "yes":
                            System.Console.Clear();
                            Directory.Delete(@"0:\system", true);
                            Directory.Delete(@"0:\home", true);
                            File.Delete(@"0:\var\tmp\temp.tmp");
                            Power.CPUReboot();
                            break;
                        case "n" or "no":
                            File.Delete(@"0:\var\tmp\temp.tmp");
                            System.Console.WriteLine("Stoped.");
                            break;
                        default:
                            File.Delete(@"0:\var\tmp\temp.tmp");
                            System.Console.WriteLine("Auto. Stoped. ");
                            break;
                    }

                    break;
                }
            }
        }

        #endregion endSystem
    }
}