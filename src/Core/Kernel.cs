#region

// using Cosmos.System.Graphics;
using System;
using System.IO;
using Cosmos.Core;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Milkysharp.Cli;
using Milkysharp.Console;
using Milkysharp.Cui;
using Milkysharp.Screens;
using Milkysharp.SystemMain;
using static Milkysharp.Cli.MethodsInfo;
using Sys = Cosmos.System;

#endregion

namespace Milkysharp.Core;

public class Kernel : Sys.Kernel
{
    public const string UserKitVer = "20220209";
    public const string Ver = "2.1";
    public const string CuiVer = "2.0";
    public const string OsName = "Milkysharp";
    public const string ShVer = "0.2";
    public const string ShName = "milkysh";
    public const string CurrentVolume = @"0:\";
    public static CosmosVFS Vfs = new();
    public static string CurrentDirectory = @"0:\";
    public static string Username;
    public static bool AutoLogin;
    public static bool SetupStatus;
    public static object CurrentTime = DateTime.Now;
    public static string LatestUpdate = "13.07.2022";

    // COUNTERS
    public static float CpuUsage = 0;

    // RAM
    public static uint TotalRAM => CPU.GetAmountOfRAM();

    public static void ShowRAM()
    {
        System.Console.Write(TotalRAM + "MB\n");
    }

    protected override void BeforeRun()
    {
        try
        {
            System.Console.WriteLine("-------------------------------");

            // # file system
            if (VfsInit(Vfs))
            {
                ConsoleOk("Filesystem");
            }
            else
            {
                ConsoleError("Filesystem");
                Methods.WriteLine("\nThe system requires a FAT32 format disk.", ConsoleColor.Red);
                System.Console.ReadKey();
                Power.CPUReboot();
            }

            if (File.Exists(@"0:\br.mcf")) SetupStatus = true;
            else if (!File.Exists(@"0:\br.mcf")) SetupStatus = false;
        }
        catch (Exception e)
        {
            Crush.CrushScreen(e);
        }
    }

    protected override void Run()
    {
        System.Console.Clear();
        if (Configurator.Init())
        {
            Methods.WriteLine("\n\nSelecting the interface.", ConsoleColor.White);
            Methods.WriteLine("[ 1. CLI ]\n[ 2. CUI ]", ConsoleColor.Gray);
            while (true)
                switch (System.Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Terminal.Main();
                        break;
                    case '2':
                        Boot.Init();
                        break;
                    default:
                        Methods.WriteLine("Choose one of the two options. Use the number buttons 1 and 2.",
                            ConsoleColor.DarkYellow);
                        break;
                }
        }
    }

    public static bool VfsInit(CosmosVFS vfs)
    {
        try
        {
            static bool ContainsVolumes(VFSBase vfs)
            {
                return vfs.GetVolumes().Count != 0;
            }

            VFSManager.RegisterVFS(vfs); // Reg vfs
            if (ContainsVolumes(vfs)) return true;
            return false;
        }
        catch (Exception e)
        {
            Crush.CrushScreen(e);
            return false;
        }
    }
}