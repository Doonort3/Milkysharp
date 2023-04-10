#region
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
#endregion

namespace Milkysharp.Cui
{
    using System;
    using System.IO;

    public class Boot
    {
        public static void Init()
        {
            Libraries.Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);

            PCScreenFont font = PCScreenFont.Default;
            VGAScreen.SetFont(font.CreateVGAFont(), font.Height);

            Libraries.Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);

            if (File.Exists(@"0:\system\config\stat.mcf"))
            {
                string stat = File.ReadAllText(@"0:\system\config\stat.mcf");
                if (stat == "1")
                {
                    Main.Start();
                } 
                else
                {
                    Greetings();
                }
            }
            else
            {
                Greetings();
            }
        }

        public static void Greetings()
        {
            if (Libraries.Box.MsgBox("Hello, geek!", $"Welcome to Milkysharp CUI Mode {Core.Kernel.CuiVer}!", false, 35, back: ConsoleColor.Black, text: ConsoleColor.White, bar: ConsoleColor.Gray, x:12, y: 14))
            {
                Libraries.Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                Libraries.Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
            }

            if (Libraries.Box.MsgBox("What's this?", $"Right now you have a desktop and a terminal\n" +
                $"in front of you where you can type commands\n" +
                $"but, unlike cli mode, they are from character interfaces,\n" +
                $"for example, this mode has a very real explorer.", false, 60, back: ConsoleColor.Black, text: ConsoleColor.White, bar: ConsoleColor.Gray, x: 12, y: 8))
            {
                Libraries.Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                Libraries.Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
            }

            if (Libraries.Box.MsgBox("Onward to adventure!", "Try this mode and find 10 different files. \nGood luck, my kitten <3", false, 25, back: ConsoleColor.Black, text: ConsoleColor.White, bar: ConsoleColor.Gray, x: 12, y: 8))
            {

                if (!File.Exists(@"0:\system\config\stat.mcf"))
                {
                    File.Create(@"0:\system\config\stat.mcf");
                    File.WriteAllText(@"0:\system\config\stat.mcf", "1");

                    Libraries.Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                    Libraries.Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);

                    Main.Start();

                } 
                else if (File.Exists(@"0:\system\config\stat.mcf"))
                {
                    Init();
                }
                Main.Start();

            }
        }
    }
}