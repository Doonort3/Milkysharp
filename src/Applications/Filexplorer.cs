using System;
using System.IO;
using Milkysharp.Libraries;

namespace Milkysharp.Applications;

public class Filexplorer
{
    public static void Init(string path)
    {
        if (!path.EndsWith(@"\")) path += @"\";

        for (;;)
        {
            if (!Directory.Exists(path)) continue;
            var x = 20;
            var f = 0;
            var y = 7;
            var fx = 0;
            var fy = 0;

            Window.DrawWindow("Explorer", 43, 19, 19, 0);

            var dirs = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            System.Console.ForegroundColor = ConsoleColor.Black;

            System.Console.SetCursorPosition(x, y - 4);
            System.Console.Write("Path: [");
            System.Console.Write(path);
            System.Console.SetCursorPosition(x + 39, y - 4);
            System.Console.Write("]");
            System.Console.SetCursorPosition(x, y - 2);


            for (var index = 0; index < dirs.Length; index++)
            {
                var t = dirs[index];
                var actual = t.Replace(path, "");
                if (actual.Length > 20)
                {
                    do
                    {
                        actual = actual.Remove(actual.Length - 1, 1);
                    } while (actual.Length > 10);

                    f++;
                    actual += "~" + f;
                }

                actual += @"\";
                System.Console.Write(actual);
                System.Console.SetCursorPosition(x + 18, y - 2);
                System.Console.Write("type: directory");
                System.Console.SetCursorPosition(x, y - 1);
                y++;
                if (y == 20)
                {
                    y = 7;
                    x += 16;
                }
            }

            fy = y;
            fx = x;


            for (var index = 0; index < files.Length; index++)
            {
                var t = files[index];
                var actual = t.Replace(path, "");
                if (actual.Length > 20)
                {
                    var ext = actual.Substring(actual.Length - 4);
                    do
                    {
                        actual = actual.Remove(actual.Length - 1, 1);
                    } while (actual.Length > 8);

                    f++;
                    actual += "~" + f + ext;
                }

                System.Console.Write(actual);
                System.Console.SetCursorPosition(fx + 18, fy - 2);
                System.Console.Write("type: file");
                System.Console.SetCursorPosition(fx, fy - 1);
                fy++;

                if (fy != 20) continue;

                fy = 7;
                fx += 16;
            }

            System.Console.SetCursorPosition(20, 2);
            var npath = Read.TextBox(37);

            if (!File.Exists($"0:{npath}") && npath != "/exit" && npath != "/ver" && npath.Contains("/"))
            {
                Box.MsgBox("Err", $"Incorrect input. \n{npath}", false, npath.Length + 20);
                Init(path);
                return;
            }

            /*if (npath.EndsWith(".txt"))
            {
                return;
            }
            else if (!npath.EndsWith(@"\"))
            {
                npath += @"\";
            }*/


            if (npath == "/exit")
            {
                Window.CloseWindows(0, 19, 43, 20, ConsoleColor.Black);
                Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB) ...");
                return;
            }

            if (npath == "/ver")
            {
                Box.MsgBox("Information", "program: Explorer\nver: 2.0\ndevs: Luftkatze, Doonort3", false, 41, 13, 19);
                Window.CloseWindows(13, 19, 42, 8, ConsoleColor.Black);
                Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB) ...");
                Init(path);
                return;
            }

            if (npath == "\\")
            {
                path = $"0:{npath}";
            }
            else if (npath.StartsWith(@"\"))
            {
                if (Directory.Exists($"0:{npath}\\") && npath != "\\")
                {
                    path = $"0:{npath}\\";
                }
                else if (File.Exists($"0:{npath}"))
                {
                    if (npath == "\\bf.mcf")
                    {
                        Box.MsgBox("Err", $"This file is protected by system.\n" +
                                          $"Cannot be edit.", false, npath.Length + 32, x: 20);
                    }
                    else
                    {
                        MIVMain.mivEditor($"0:{npath}");
                        Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                        Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB) ...");
                    }
                }
                else if (!Directory.Exists($"0:{npath}") & !File.Exists($"0:{npath}\\"))
                {
                    Box.MsgBox("Err", $"Cannot find directory:\n {path}{npath}", false, npath.Length + 30);
                    Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
                }
            }
            else if (!npath.StartsWith(@"\") & Directory.Exists(path + npath + "\\"))
            {
                path += npath + "\\";
            }
            else if (!npath.StartsWith(@"\") & File.Exists(path + npath))
            {
                if (npath == "bf.mcf")
                {
                    Box.MsgBox("Err", $"This file is protected by system.\n" +
                                      $"Cannot be edit.", false, npath.Length + 32, x: 20);
                }
                else
                {
                    MIVMain.mivEditor(path + npath);
                    Screen.ClearScreen(ConsoleColor.Black, ConsoleColor.White);
                    Menu.Bar("Programs (Enter) | Explorer (E) | Shutdown (S) | Reboot (R) | Terminal (TAB) ...");
                }
            }
            else if (!File.Exists(path + npath) & !Directory.Exists(path + npath + "\\"))
            {
                Box.MsgBox("Err", "Cannot find file or directory:\n" + npath, false, npath.Length + 30);
                Desktop.Draw(ConsoleColor.Black, ConsoleColor.White);
            }
        }
    }

    /*public static void NewFileExplorer(string path)
    {
        if (!path.EndsWith(@"\")) path += @"\";
        else
        {
            #region Draw window
            Window.DrawWindow("Explorer", 40, 20, 2, 1);
            #endregion
            #region Variables
            // Func for get file and get dirs
            var getFiles = Directory.GetFiles(path);
            var getFolders = Directory.GetDirectories(path);
            // idk
            var x = 3;
            var f = 0;
            var y = 7;
            var fx = 0;
            var fy = 0;
            #endregion
            #region Set cursor position and write block for path txt
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y - 3);
            Console.Write("[" + path + "]:");
            Console.SetCursorPosition(x, y - 1);
            Console.SetCursorPosition(3, 3);
            #endregion
            #region Get list of dirs
            foreach (var t in getFolders)
            {
                var actual = t.Replace(path, "");
                if (actual.Length > 12)
                {
                    do
                    {
                        actual = actual.Remove(actual.Length - 1, 1);
                    } while (actual.Length > 10);
                    f++;
                    actual += "~" + f;
                }
                actual += @"\";
                Console.Write(actual);
                Console.SetCursorPosition(x, y);
                y++;
                if (y == 21)
                {
                    y = 7;
                    x += 16;
                }
                fy = Console.CursorTop;
                fx = Console.CursorLeft;
            }
            #endregion
            #region Get list of file
            foreach (var t in getFiles)
            {
                var actual = t.Replace(path, "");
                if (actual.Length > 12)
                {
                    var ext = actual.Substring(actual.Length - 4);
                    do
                    {
                        actual = actual.Remove(actual.Length - 1, 1);
                    } while (actual.Length > 8);
                    f++;
                    actual += "~" + f + ext;
                }
                #region Write actual path
                Console.Write(actual);
                Console.SetCursorPosition(fx, fy);
                fy++;
                if (fy != 21) continue;
                fy = 7;
                fx += 16;
                #endregion
            }
            #endregion
            #region Path entry and check
            var inputPath = Read.TextBox(65);
            var finallyPath = path + inputPath;
            if (!inputPath.EndsWith(@"\")) inputPath += @"\";
            if (Directory.Exists(finallyPath))
            {
                path += inputPath;
            } 
            else if (File.Exists(finallyPath))
            {
                Looti.Run(finallyPath.ToStringArr());
            }
            else
            {
                Box.MsgBox("Error", "Cannot find directory:\n" + path, false, path.Length + 25);
            }
            #endregion
        }
    }*/
}