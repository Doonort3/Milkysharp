#region

using System;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
// using Cosmos.System.Graphics;
using Milkysharp.Cli;
using Milkysharp.Console;
using Milkysharp.SystemMain;
using Power = Cosmos.HAL.Power;
using Sys = Cosmos.System;

#endregion

namespace Milkysharp.Core
{
    public class Kernel : Sys.Kernel
    {
        public const string UserKitVer = "20220209";
        public const string Ver = "0.2";
        public const string CuiVer = "1.0";
        public const string OsName = "Milkysharp";
        public const string ShVer = "0.2";
        public const string ShName = "milkysh";
        public const string CurrentVolume = @"0:\";
        public static CosmosVFS Vfs = new();
        public static string CurrentDirectory = @"0:\";
        public static string Username;
        public static bool AutoLogin;

        protected override void BeforeRun()
        {
            try
            {
                // VGAScreen.SetTextMode(VGADriver.TextSize.Size80x50);
                System.Console.WriteLine("-------------------------------");

                // # file system
                if (VfsInit(Vfs))
                {
                    Methods.WriteLine("FILESYSTEM >> OK", ConsoleColor.Green);
                }
                else
                {
                    Methods.WriteLine("FILESYSTEM >> ERROR\n", ConsoleColor.Red);
                    Methods.WriteLine("The system requires a FAT32 format disk.", ConsoleColor.Red);
                    System.Console.ReadKey();
                    Power.CPUReboot();
                }
            }
            catch
            {
                System.Console.Clear();
                System.Console.WriteLine("Kernel panic!");
                System.Console.ReadKey();
                Power.CPUReboot();
            }
        }

        protected override void Run()
        {
            System.Console.Clear();
            if (Configurator.Init())
            {
                System.Console.WriteLine("Selecting the interface.");
                System.Console.WriteLine("1. CLI\n2. CUI");
                while (true)
                {
                    switch (System.Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            Terminal.Main();
                            break;
                        case '2':
                            Cui.Boot.Init();
                            break;
                        default: System.Console.WriteLine("Choose one of the two options. Use the number buttons 1 and 2."); break;
                    }
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
            catch
            {
                System.Console.Clear();
                System.Console.WriteLine("VFS panic!");
                System.Console.ReadKey();
                Power.CPUReboot();
                return false;
            }
        }
    }
}