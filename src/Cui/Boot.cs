#region

using System;
using System.IO;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Milkysharp.Core;
using Milkysharp.Libraries;

#endregion

namespace Milkysharp.Cui;

public class Boot
{
    public static void Init()
    {
        Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);

        PCScreenFont font = PCScreenFont.Default;
        VGAScreen.SetFont(font.CreateVGAFont(), font.Height);

        if (File.Exists(@"0:\system\config\stat.mcf"))
        {
            string stat = File.ReadAllText(@"0:\system\config\stat.mcf");
            if (stat == "1")
                Main.Start();
            else
                Greetings();
        }
        else
        {
            Greetings();
        }
    }

    public static void Greetings()
    {
        if (Box.MsgBox("Hello, geek!", $"Welcome to Milkysharp CUI Mode {Kernel.CuiVer}!", false, 35, x: 22, y: 10))
            Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);

        if (Box.MsgBox("What's this?",
                $"Right now you have a desktop and a terminal\n" + $"in front of you where you can type commands\n" +
                $"but, unlike cli mode, they are from character interfaces,\n" +
                $"for example, this mode has a very real explorer.", false, 60, x: 11, y: 9))
            Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);

        if (Box.MsgBox("Onward to adventure!", "Good luck, my kitten <3", false, 28, x: 22, y: 10))
        {
            Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
            Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
        }

        if (Box.MsgBox("In the new version",
                $"Version {Kernel.CuiVer}:\n" + $"* Dock Bar\n" + $"* Explorer\n" + $"* Terminal\n" +
                $"* Hotkeys for Shutdown and Reboot\n" + $"* Program list\n" + $"* File editor MIV", false, 40, x: 20,
                y: 6))
        {
            if (!File.Exists(@"0:\system\config\stat.mcf"))
            {
                File.Create(@"0:\system\config\stat.mcf");
                File.WriteAllText(@"0:\system\config\stat.mcf", "1");

                Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);

                Main.Start();
            }
            else if (File.Exists(@"0:\system\config\stat.mcf"))
            {
                if (File.ReadAllText(@"0:\system\config\stat.mcf") != "1")
                    File.WriteAllText(@"0:\system\config\stat.mcf", "1");

                Init();
            }

            Main.Start();
        }
    }
}