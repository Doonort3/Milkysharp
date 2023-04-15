#region

using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.HAL;
using Milkysharp.Applications;
using Milkysharp.Cli;
using Milkysharp.Core;
using Milkysharp.Cui;
using Milkysharp.Other;
using Milkysharp.Screens;

#endregion

namespace Milkysharp.Console;

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
                Cosmos.HAL.Power.CPUReboot();
            }
        }
        else if (arguments.Count == 0)
        {
            Methods.WriteLine("Syntax error. Use \"run --help (-h)\" command.", ConsoleColor.Red);
        }
    }*/

    /* public static void RunStandart(List<string> arguments, string progName, string commandName)
    {
            if (progName.EndsWith(".bin"))
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

            if (progName.EndsWith(".bin"))
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
    }*/

    /*public static void Edit(List<string> arguments)
    {
        string fileName = arguments[0];
        
        switch (arguments.Count)
        {
            case 1 when arguments[0].ToLower() is "-h" or "--help":
                Methods.Help("{file}", @"$ edit {file}", "Opens the text editor of the specified file.");
                break;
            case 0:
                Methods.WriteLine("Syntax error. Use \"edit --help (-h)\" command.", ConsoleColor.Red);
                System.Console.ReadLine();
                break;
            case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                if (arguments[0].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentVolume + fileName))
                    {
                        MIVMain.StartMIV(fileName);
                    }
                    else
                    {
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                }
                else if (!arguments[0].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentDirectory + fileName))
                    {
                        MIVMain.StartMIV(fileName);
                    }
                    else
                    {
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                    }
                }
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Kernel panic!");
                    System.Console.ReadKey();
                    Power.CPUReboot();
                }
                break;
            case > 2:
                Methods.WriteLine("Syntax error. Use \"edit --help (-h)\" command.", ConsoleColor.Red);
                break;

        }
    }*/

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
                    "> Type: Standart", "CMD: cls\\clear ---------------- DESC: Clearing the terminal screen.",
                    "CMD: pwd ---------------------- DESC: Display the current directory.",
                    "CMD: ver ---------------------- DESC: Display current version.",
                    "CMD: changelog ---------------- DESC: Display changelog for current version.", "> Type: FS ",
                    "CMD: mkdir -------------------- DESC: Creating a new folder.",
                    "CMD: cd ----------------------- DESC: Changing the working directory.",
                    "CMD: ls ----------------------- DESC: Display all folders and files.",
                    "CMD: rm ----------------------- DESC: Deleting file or a directory.",
                    "CMD: cp ----------------------- DESC: Copies the file to the spec. folder.",
                    "CMD: touch -------------------- DESC: Create a file.",
                    "CMD: edit --------------------- DESC: File editor.",
                    "CMD: mv ----------------------- DESC: Move the file.",
                    "CMD: cat ---------------------- DESC: Read all lines of text.",
                    "CMD: cui ---------------------- DESC: Switch to CUI mode.", "> Type: Power",
                    "CMD: shutdown ----------------- DESC: Turn off the computer.",
                    "CMD: reboot ------------------- DESC: Reboot the computer.", "> Type: System",
                    // "CMD: run ---------------------- DESC: Running a program.",
                    "CMD: reconf ------------------- DESC: Reinstalling the system.\n"
                };
                foreach (var command in commands) System.Console.WriteLine($"{command}");
                System.Console.WriteLine("To output a detailed command description, \n" +
                                         "type \"commandName -h\" or \"commandName --help\" eg.\"mkdir -h\"");
                break;
            }
        }
    }

    public static void Version(List<string> arguments)
    {
        Methods.WriteLine(
            "" + "\r\n   __  ____ ____            __               " +
            "\r\n  /  |/  (_) / /____ _____ / /  ___ ________ " +
            "\r\n / /|_/ / / /  '_/ // (_-</ _ \\/ _ `/ __/ _ \\" +
            "\r\n/_/  /_/_/_/_/\\_\\\\_, /___/_//_/\\_,_/_/ / .__/" +
            "\r\n                /___/                 /_/    " + "\r\n", ConsoleColor.Blue);
        Methods.WriteLine($"Milkysharp ver. {Kernel.Ver}", ConsoleColor.White);
        // $"\nCurrent time: {Kernel.CurrentTime}" +
        Methods.WriteLine("Created at: 20.06.2022", ConsoleColor.White);
        Methods.WriteLine($"\nLatest update: {Kernel.LatestUpdate}", ConsoleColor.White);
        Methods.Write("\nRAM capacity: ", ConsoleColor.White);
        Kernel.ShowRAM();
    }

    public static void ChangeLog()
    {
        Methods.WriteLine($"\nWhat's new in the version {Kernel.Ver}", ConsoleColor.Yellow);
        Methods.WriteLine("* CUI mode (cui)", ConsoleColor.White);
        Methods.WriteLine("* Text editor (edit)", ConsoleColor.White);
        Methods.WriteLine("* The command that outputs the version (ver)", ConsoleColor.White);
        Methods.WriteLine("* Recovery program (Recovery Systems Directories program)", ConsoleColor.White);
        Methods.WriteLine("* New PS1", ConsoleColor.White);
        Methods.WriteLine("* The system configurator has been changed slightly.", ConsoleColor.White);
        Methods.WriteLine("* The teams were divided into sections", ConsoleColor.White);
        Methods.WriteLine("* Bug fixed", ConsoleColor.White);
        Methods.WriteLine("* And much more!\n", ConsoleColor.White);
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
                var dirName = arguments[0];
                if (arguments[0].StartsWith("\\"))
                {
                    if (!Directory.Exists(Kernel.CurrentVolume + dirName))
                    {
                        if (!dirName.Contains('.') && !dirName.Contains("/") && !dirName.Contains(':') &&
                            !dirName.Contains('*') && !dirName.Contains('?') && !dirName.Contains('<') &&
                            !dirName.Contains('>') && !dirName.Contains('|') && !dirName.Contains('+') &&
                            !dirName.Contains(' '))
                            Directory.CreateDirectory(Kernel.CurrentVolume + dirName);
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
                    Crush.CrushScreenWithoutException();
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
                if (Kernel.CurrentDirectory == @"0:\\") Kernel.CurrentDirectory = Kernel.CurrentVolume;

                if (arguments.Count > 0 && dir is "..")
                {
                    if (Kernel.CurrentDirectory == @"0:\" || Kernel.CurrentDirectory == @"0:\\")
                    {
                        Methods.WriteLine("This is the root folder.", ConsoleColor.Red);
                        return;
                    }

                    Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                    var root = Kernel.Vfs.GetDirectory(Kernel.CurrentDirectory);
                    if (Kernel.CurrentDirectory != Kernel.CurrentVolume)
                        Kernel.CurrentDirectory = root.mParent.mFullPath + @"\";
                }
                else if (dir == @"\home")
                {
                    Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                    Kernel.CurrentDirectory = Kernel.CurrentVolume + @"home\" + Kernel.Username + @"\";
                }
                else if (dir == "\\")
                {
                    Directory.SetCurrentDirectory(Kernel.CurrentDirectory);
                    Kernel.CurrentDirectory = Kernel.CurrentVolume;
                }
                else if (dir == Kernel.CurrentVolume)
                {
                    Kernel.CurrentDirectory = Kernel.CurrentVolume;
                }
                else if (dir.StartsWith("\\") && dir != "\\")
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
                    Crush.CrushScreenWithoutException();
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
                    else if (Directory.Exists(Kernel.CurrentVolume + arguments[1] + "\\"))
                        Directory.Delete(Kernel.CurrentVolume + arguments[1], true);
                    else if (!Directory.Exists(Kernel.CurrentVolume + arguments[1] + "\\"))
                        Methods.WriteLine("ERROR: This directory doesn't exist.", ConsoleColor.Red);
                }
                else if (!arguments[1].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentDirectory + arguments[1]))
                        Methods.WriteLine("ERROR: This is a file.", ConsoleColor.Red);
                    else if (Directory.Exists(Kernel.CurrentDirectory + arguments[1] + "\\"))
                        Directory.Delete(Kernel.CurrentDirectory + arguments[1] + "\\", true);
                    else if (!Directory.Exists(Kernel.CurrentDirectory + arguments[1] + "\\"))
                        Methods.WriteLine("ERROR: This directory doesn't exist.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
                }

                break;
            }
            case > 0 when arguments[0].ToLower() is not "-r" or "--help" or "-h":
            {
                if (arguments[0].StartsWith("\\"))
                {
                    if (arguments[0] == "\\bf.mcf")
                    {
                        Methods.WriteLine("ERROR: This file is protected by the system and cannot be deleted.",
                            ConsoleColor.Red);
                    }
                    else
                    {
                        if (Directory.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("ERROR: This is a folder.", ConsoleColor.Red);
                        else if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                            File.Delete(Kernel.CurrentVolume + arguments[0]);
                        else if (!File.Exists(Kernel.CurrentVolume + arguments[0]))
                            Methods.WriteLine("ERROR: This file doesn't exist.", ConsoleColor.Red);
                    }
                }
                else if (!arguments[0].StartsWith("\\"))
                {
                    if (arguments[0] == "bf.mcf")
                    {
                        Methods.WriteLine("ERROR: This file is protected by the system and cannot be deleted.",
                            ConsoleColor.Red);
                    }
                    else
                    {
                        if (Directory.Exists(Kernel.CurrentDirectory + arguments[0]))
                            Methods.WriteLine("ERROR: This is a folder.", ConsoleColor.Red);
                        else if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            File.Delete(Kernel.CurrentDirectory + arguments[0]);
                        else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]))
                            Methods.WriteLine("ERROR: This file doesn't exist.", ConsoleColor.Red);
                    }
                }
                else
                {
                    Crush.CrushScreenWithoutException();
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
                        File.Copy(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1], true);
                    else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]) &&
                             !Directory.Exists(Kernel.CurrentDirectory + arguments[1]))
                        Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
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
                        catch (Exception e)
                        {
                            Methods.WriteLine($"Error in creating the file.\nError: {e}", ConsoleColor.Red);
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
                        catch (Exception e)
                        {
                            Methods.WriteLine($"Error in creating the file.\nError: {e}", ConsoleColor.Red);
                        }
                    else if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                        Methods.WriteLine("ERROR: File already exist.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
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
                            File.Copy(Kernel.CurrentVolume + arguments[0], Kernel.CurrentVolume + arguments[1], true);
                            File.Delete(Kernel.CurrentVolume + arguments[0]);
                            // File.Move(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1]);
                        }
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while moving the file.\nError: {e}",
                                ConsoleColor.Red);
                        }
                    else if (!File.Exists(@"0:\" + arguments[0]) && !Directory.Exists(@"0:\" + arguments[1]))
                        Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                }
                else if (!arguments[0].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                        try
                        {
                            File.Copy(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentVolume + arguments[1],
                                true);
                            File.Delete(Kernel.CurrentDirectory + arguments[0]);
                            // File.Move(Kernel.CurrentDirectory + arguments[0], Kernel.CurrentDirectory + arguments[1]);
                        }
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while moving the file.\nError: {e}",
                                ConsoleColor.Red);
                        }
                    else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]) &&
                             !Directory.Exists(Kernel.CurrentVolume + arguments[1]))
                        Methods.WriteLine("ERROR: File or dir doesn't exist.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
                    ;
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
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while reading file\nError: {e}", ConsoleColor.Red);
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
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while reading file\nError: {e}", ConsoleColor.Red);
                        }
                    else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]))
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
                }

                break;
            }
            case 0:
                Methods.WriteLine("Syntax error. Use \"cat --help (-h)\" command.", ConsoleColor.Red);
                break;
        }
    }

    public static void Edit(List<string> arguments)
    {
        switch (arguments.Count)
        {
            case 1 when arguments[0].ToLower() is "--help" or "-h":
                Methods.Help("{file}", @"$ edit {file}", "Open the MIV to edit the file.");
                break;
            case > 1 when arguments[0].ToLower() is "-h" or "--help":
                Methods.WriteLine("Syntax error. Use \"edit --help (-h)\" command.", ConsoleColor.Red);
                break;
            case 1 when arguments[0].ToLower() is not "-h" or "--help":
            {
                if (arguments[0].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentVolume + arguments[0]))
                        try
                        {
                            MIVMain.mivEditor($"0:{arguments[0]}");
                        }
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while reading file\nError: {e}", ConsoleColor.Red);
                        }
                    else if (!File.Exists(Kernel.CurrentVolume + arguments[0]))
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                }
                else if (!arguments[0].StartsWith("\\"))
                {
                    if (File.Exists(Kernel.CurrentDirectory + arguments[0]))
                        try
                        {
                            MIVMain.mivEditor($"{Kernel.CurrentDirectory}{arguments[0]}");
                        }
                        catch (Exception e)
                        {
                            Methods.WriteLine($"An error occurred while reading file\nError: {e}", ConsoleColor.Red);
                        }
                    else if (!File.Exists(Kernel.CurrentDirectory + arguments[0]))
                        Methods.WriteLine("File not found.", ConsoleColor.Red);
                }
                else
                {
                    Crush.CrushScreenWithoutException();
                }

                break;
            }
            case 0:
                Methods.WriteLine("Syntax error. Use \"edit --help (-h)\" command.", ConsoleColor.Red);
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

    public static void ActivateCUI(List<string> arguments)
    {
        switch (arguments.Count)
        {
            case 1 when arguments[0].ToLower() is "-h" or "--help":
                Methods.Help("null", "$ cui", "Switch to cui interface mode.");
                break;
            case > 1 when arguments[0].ToLower() is "-h" or "--help":
                Methods.WriteLine("Syntax error. Use \"cui --help (-h)\" command.", ConsoleColor.Red);
                break;
            case 0:
            {
                Boot.Init();
                break;
            }
            case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                Methods.WriteLine("Syntax error. Use \"cui --help (-h)\" command.", ConsoleColor.Red);
                break;
        }
    }

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
                switch (temp.ToLower())
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

                if (File.Exists(@"0:\var\tmp\temp.tmp")) File.Delete(@"0:\var\tmp\temp.tmp");
                break;
            }
            case > 0 when arguments[0].ToLower() is not "--help" or "-h":
                Methods.WriteLine("Syntax error. Use \"poweroff --help (-h)\" command.", ConsoleColor.Red);
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
                switch (temp.ToLower())
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

                if (File.Exists(@"0:\var\tmp\temp.tmp")) File.Delete(@"0:\var\tmp\temp.tmp");
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
                        try
                        {
                            if (Directory.Exists(@"0:\system")) Directory.Delete(@"0:\system", true);
                            if (Directory.Exists(@"0:\home")) Directory.Delete(@"0:\home", true);
                            if (Directory.Exists(@"0:\bin")) Directory.Delete(@"0:\bin", true);
                            if (Directory.Exists(@"0:\usr")) Directory.Delete(@"0:\usr", true);
                            if (Directory.Exists(@"0:\var")) Directory.Delete(@"0:\var", true);

                            if (File.Exists(@"0:\bf.mcf")) File.Delete(@"0:\bf.mcf");
                        }
                        catch (Exception e)
                        {
                            Crush.CrushScreen(e);
                        }

                        Power.CPUReboot();
                        break;
                    case "n" or "no":
                        System.Console.WriteLine("Stoped.");
                        break;
                    default:
                        System.Console.WriteLine("Auto. Stoped. ");
                        break;
                }

                break;
            }
        }
    }

    #endregion endSystem
}