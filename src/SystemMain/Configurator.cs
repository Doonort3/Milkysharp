#region

using System;
using System.IO;
using System.Text;
using Cosmos.HAL;
using Milkysharp.Cli;
using Milkysharp.Core;
using Milkysharp.Screens;

#endregion

namespace Milkysharp.SystemMain;

public class Configurator
{
    public static bool Init()
    {
        System.Console.Clear();
        System.Console.BackgroundColor = ConsoleColor.Black;
        System.Console.ForegroundColor = ConsoleColor.White;
        System.Console.Clear();

        try
        {
            System.Console.WriteLine("\nWelcome to the Milkysharp loader!");

            if (SysFoldersAndFiles())
                MethodsInfo.ConsoleOk("system dirs");
            else
                Recovery.RecoverySystemDirs();

            if (CreateUser())
            {
                MethodsInfo.ConsoleOk("configs");

                try
                {
                    if (!File.Exists(@"0:\bf.mcf"))
                    {
                        File.Create(@"0:\bf.mcf");
                        Power.CPUReboot();
                        return true;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
            else
            {
                MethodsInfo.ConsoleError("user config");
                System.Console.ReadLine();
                Crush.CrushScreenWithoutException(); // TODO: сделать востановление пользователя
            }
        }
        catch (Exception e)
        {
            Crush.CrushScreen(e);
            return false;
        }

        return true;
    }

    public static bool SysFoldersAndFiles()
    {
        try
        {
            #region ClearDisk

            if (Directory.Exists(@"0:\Dir Testing") && Directory.Exists(@"0:\test"))
            {
                Directory.Delete(@"0:\Dir Testing", true);
                Directory.Delete(@"0:\test", true);
            }

            if (File.Exists(@"0:\Kudzu.txt") && File.Exists(@"0:\Root.txt"))
            {
                File.Delete(@"0:\Kudzu.txt");
                File.Delete(@"0:\Root.txt");
            }

            #endregion endClearDisk

            if (!File.Exists(@"0:\bf.mcf"))
            {
                // System files
                if (!Directory.Exists(@"0:\system"))
                {
                    Directory.CreateDirectory(@"0:\system");

                    if (!Directory.Exists(@"0:\system\config")) Directory.CreateDirectory(@"0:\system\config");
                }

                // User folder
                if (!Directory.Exists(@"0:\home")) Directory.CreateDirectory(@"0:\home");

                // User applications and tools
                if (!Directory.Exists(@"0:\usr"))
                {
                    Directory.CreateDirectory(@"0:\usr");

                    if (!Directory.Exists(@"0:\usr\bin")) Directory.CreateDirectory(@"0:\usr\bin");
                }

                // Changeable and temporary files
                if (!Directory.Exists(@"0:\var"))
                {
                    Directory.CreateDirectory(@"0:\var");

                    if (!Directory.Exists(@"0:\var\log"))
                    {
                        Directory.CreateDirectory(@"0:\var\log");
                        File.Create(@"0:\var\log\main.log");
                    }

                    if (!Directory.Exists(@"0:\var\tmp")) Directory.CreateDirectory(@"0:\var\tmp");
                }

                return true;
            }

            if (Directory.Exists(@"0:\system") && Directory.Exists(@"0:\system\config")
                                               && Directory.Exists(@"0:\home") && Directory.Exists(@"0:\usr")
                                               && Directory.Exists(@"0:\usr\bin") && Directory.Exists(@"0:\var")
                                               && Directory.Exists(@"0:\var\log") && File.Exists(@"0:\bf.mcf"))
                return true;

            Recovery.RecoverySystemDirs();
            return false;
        }
        catch
        {
            return false;
        }
    }


    public static bool CreateUser()
    {
        if (!File.Exists(@"0:\system\config\user.mcf") && !File.Exists(@"0:\system\config\autologin.mcf"))
        {
            MethodsInfo.ConsoleInfo("User creating\n");
            a:
            System.Console.Write("\n[Username]: ");
            var tempUsername = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(tempUsername) && !string.IsNullOrWhiteSpace(tempUsername) &&
                char.IsLetter(tempUsername, 1) && char.IsLower(tempUsername, 1))
            {
                p:
                System.Console.Write("[Password]: ");
                var tempPassword = GetPassword();
                System.Console.Write("[Re-type password]: ");
                var tempRetypePassword = GetPassword();

                if (tempPassword != tempRetypePassword)
                {
                    System.Console.WriteLine("The passwords don't match. Please, try again.");
                    goto p;
                }

                if (!string.IsNullOrEmpty(tempPassword) && !string.IsNullOrWhiteSpace(tempPassword))
                {
                    if (Directory.Exists(@"0:\system\config"))
                        try
                        {
                            // Generate user.mcf and write username and password to it
                            File.Create(@"0:\system\config\user.mcf");
                            File.WriteAllText(@"0:\system\config\user.mcf", $"{tempUsername}:{tempPassword}");

                            // Configurate autologin in system
                            System.Console.WriteLine("\nLog in automatically? Y/n");

                            var keyPress = System.Console.ReadKey(false);

                            switch (keyPress.Key)
                            {
                                case ConsoleKey.Y:
                                    try
                                    {
                                        // Generate autologin.mcf and write status of run autologin to it
                                        File.Create(@"0:\system\config\autologin.mcf");
                                        File.WriteAllText(@"0:\system\config\autologin.mcf", "on");
                                    }
                                    catch (Exception e)
                                    {
                                        Crush.CrushScreen(e);
                                    }

                                    break;
                                case ConsoleKey.N:
                                    try
                                    {
                                        // Generate autologin.mcf and write status of run autologin to it
                                        File.Create(@"0:\system\config\autologin.mcf");
                                        File.WriteAllText(@"0:\system\config\autologin.mcf", "off");
                                    }
                                    catch (Exception e)
                                    {
                                        Crush.CrushScreen(e);
                                    }

                                    break;
                                default:
                                    try
                                    {
                                        System.Console.WriteLine("Auto. Yes. Autologin is on.");
                                        File.Create(@"0:\system\config\autologin.mcf");
                                        File.WriteAllText(@"0:\system\config\autologin.mcf", "on");
                                    }
                                    catch (Exception e)
                                    {
                                        Crush.CrushScreen(e);
                                    }

                                    break;
                            }

                            b:
                            if (File.Exists(@"0:\system\config\user.mcf"))
                                try
                                {
                                    var tempData =
                                        File.ReadAllText(
                                            @"0:\system\config\user.mcf"); // Get username and password from user.mcf
                                    var tempUserData = tempData.Split(':'); // Split username and password with ":"
                                    var regulAutologin = File.ReadAllText(
                                        @"0:\system\config\autologin.mcf"); // Get status of autologin

                                    if (!string.IsNullOrEmpty(tempUserData[0]) &&
                                        !string.IsNullOrEmpty(tempUserData[1]))
                                    {
                                        var regulUsername = tempUserData[0];
                                        var regulPassword = tempUserData[1];


                                        Methods.WriteLine("\n\nNew user data:", ConsoleColor.Yellow);
                                        System.Console.WriteLine($"\n# Username: {regulUsername}" +
                                                                 $"\n# Password for {regulUsername}: hidden" +
                                                                 $"\n# Autologin: {regulAutologin}" +
                                                                 $"\n# Home Folder: 0:\\home\\{regulUsername}\\\n" +
                                                                 "\nConfirm user creation and reboot the system? Y/n");

                                        var userConfirmKey = System.Console.ReadKey(false);

                                        switch (userConfirmKey.Key)
                                        {
                                            case ConsoleKey.Y:
                                                Kernel.Username = regulUsername.ToLower();
                                                aa:
                                                if (Directory.Exists(@"0:\home"))
                                                    try
                                                    {
                                                        if (!Directory.Exists(@$"0:\home\{Kernel.Username}"))
                                                        {
                                                            Directory.CreateDirectory(
                                                                @$"0:\home\{Kernel.Username}\");
                                                            return true;
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Crush.CrushScreen(e);
                                                    }
                                                else if (!Directory.Exists(@"0:\home"))
                                                    try
                                                    {
                                                        Directory.CreateDirectory(@"0:\home");
                                                        goto aa;
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Crush.CrushScreen(e);
                                                    }
                                                else
                                                    Crush.CrushScreenWithoutException();

                                                break;
                                            case ConsoleKey.N:
                                                System.Console.Clear();
                                                goto a;
                                            default:
                                                Kernel.Username = regulUsername.ToLower();
                                                ab:
                                                if (Directory.Exists(@"0:\home"))
                                                    try
                                                    {
                                                        if (!Directory.Exists(@$"0:\home\{Kernel.Username}"))
                                                        {
                                                            Directory.CreateDirectory(
                                                                @$"0:\home\{Kernel.Username}\");
                                                            return true;
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Crush.CrushScreen(e);
                                                    }
                                                else if (!Directory.Exists(@"0:\home"))
                                                    try
                                                    {
                                                        Directory.CreateDirectory(@"0:\home");
                                                        goto ab;
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Crush.CrushScreen(e);
                                                    }
                                                else
                                                    Crush.CrushScreenWithoutException();

                                                break;
                                        }
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(
                                            "User data is not written to the configuration files. Write attempt...");
                                        Recovery.WriteUserDataToUserConfig(tempUsername, tempPassword);
                                        goto b;
                                    }
                                    // * Or else go to the end and return true * //
                                }
                                catch (Exception e)
                                {
                                    Crush.CrushScreen(e);
                                }
                            else if (!File.Exists(@"0:\system\config\user.mcf"))
                                try
                                {
                                    File.Create(@"0:\system\config\user.mcf");
                                    goto a;
                                }
                                catch (Exception e)
                                {
                                    Crush.CrushScreen(e);
                                }
                            else
                                Crush.CrushScreenWithoutException();
                        }
                        catch (Exception e)
                        {
                            Crush.CrushScreen(e);
                        }
                    else if (!Directory.Exists(@"0:\system\config"))
                        SysFoldersAndFiles();
                    else
                        Crush.CrushScreenWithoutException();
                }
                else
                {
                    System.Console.WriteLine("Password must be entered without space.");
                    goto a;
                }
            }
            else
            {
                System.Console.WriteLine("The username must be entered in lowercase letters, \n" +
                                         "without space and without digits at the beginning.");
                goto a;
            }
        }
        else if (File.Exists(@"0:\system\config\user.mcf") && File.Exists(@"0:\system\config\autologin.mcf"))
        {
            try
            {
                var tempData =
                    File.ReadAllText(@"0:\system\config\user.mcf"); // Get username and password from user.mcf
                var tempUserData = tempData.Split(':'); // Split username and password with ":"
                d:
                var regulAutologin =
                    File.ReadAllText(@"0:\system\config\autologin.mcf"); // Get status of autologin

                var regulUsername = tempUserData[0];
                var regulPassword = tempUserData[1];

                if (!string.IsNullOrEmpty(regulUsername) && !string.IsNullOrWhiteSpace(regulUsername) &&
                    !string.IsNullOrEmpty(regulPassword) && !string.IsNullOrWhiteSpace(regulPassword))
                {
                    if (regulAutologin == "on")
                    {
                        Kernel.Username = regulUsername;
                        if (Directory.Exists(@"0:\home"))
                            try
                            {
                                if (!Directory.Exists(@$"0:\home\{Kernel.Username}\"))
                                    Directory.CreateDirectory(@$"0:\home\{Kernel.Username}\");
                            }
                            catch (Exception e)
                            {
                                Crush.CrushScreen(e);
                            }
                        else if (!Directory.Exists(@"0:\home"))
                            try
                            {
                                Directory.CreateDirectory(@"0:\home");
                            }
                            catch (Exception e)
                            {
                                Crush.CrushScreen(e);
                            }
                        else
                            Crush.CrushScreenWithoutException();
                    }
                    else if (regulAutologin == "off")
                    {
                        System.Console.Clear();
                        System.Console.WriteLine();
                        c:
                        System.Console.Write("username: ");
                        var tempUsernameLoginString = System.Console.ReadLine();
                        if (!string.IsNullOrEmpty(tempUsernameLoginString) &&
                            !string.IsNullOrWhiteSpace(tempUsernameLoginString))
                        {
                            System.Console.Write($"password for {tempUsernameLoginString}: ");
                            var tempPasswordLoginString = GetPassword();
                            if (!string.IsNullOrEmpty(tempPasswordLoginString) &&
                                !string.IsNullOrWhiteSpace(tempPasswordLoginString))
                            {
                                if (tempUsernameLoginString != regulUsername ||
                                    tempPasswordLoginString != regulPassword)
                                {
                                    System.Console.Clear();
                                    System.Console.WriteLine("\nIncorrect user data. Please, try again.");
                                    goto c;
                                }

                                Kernel.Username = tempUsernameLoginString;
                            }
                            else
                            {
                                goto c;
                            }
                        }
                        else
                        {
                            goto c;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("The autologin configuration file does not matter. Write attempt...");
                        if (Recovery.NewValueForAutologinConfig())
                        {
                            System.Console.WriteLine("Autologin config set up!");
                            goto d;
                        }

                        System.Console.WriteLine(
                            "Autologin config failed to set up. Type 'reinstall' to start all over again, " +
                            "\n'poweroff' to turn off your computer." +
                            "\n'reboot' to restart your computer.");
                        var tempChoice = System.Console.ReadLine();
                        if (tempChoice.Trim(' ').ToLower() is "reinstall")
                        {
                            Init();
                        }
                        else if (tempChoice.Trim(' ').ToLower() is "poweroff")
                        {
                            Power.ACPIShutdown();
                        }
                        else if (tempChoice.Trim(' ').ToLower() is "reboot")
                        {
                            Power.CPUReboot();
                        }
                        else
                        {
                            System.Console.WriteLine();
                            return false;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("User data is not written to the configuration files. Write attempt...");
                    if (Recovery.WriteUserDataToUserConfig(regulUsername, regulPassword))
                    {
                        System.Console.WriteLine("User config set up!");
                        goto d;
                    }

                    System.Console.WriteLine(
                        "User config failed to set up. Type 'reinstall' to start all over again, " +
                        "\n'poweroff' to turn off your computer." +
                        "\n'reboot' to restart your computer.");
                    var tempChoice = System.Console.ReadLine();
                    if (tempChoice.Trim(' ').ToLower() is "reinstall")
                    {
                        Init();
                    }
                    else if (tempChoice.Trim(' ').ToLower() is "poweroff")
                    {
                        Power.ACPIShutdown();
                    }
                    else if (tempChoice.Trim(' ').ToLower() is "reboot")
                    {
                        Power.CPUReboot();
                    }
                    else
                    {
                        System.Console.WriteLine();
                        return false;
                    }

                    goto d;
                }
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        }
        else
        {
            Crush.CrushScreenWithoutException();
        }

        return true;
    }

    /*public static bool ManualLogin(string[] userAndPass)
    {
        login:
        Console.WriteLine("username: ");
        string usernameLogin = Console.ReadLine();
        if (!string.IsNullOrEmpty(usernameLogin) && !string.IsNullOrWhiteSpace(usernameLogin))
        {
            Console.WriteLine("password: ");
            string passLogin = Console.ReadLine();

            if (usernameLogin == userAndPass[0] && passLogin == userAndPass[1])
            {
                return true;
            }
            else
            {
                Console.Clear();
                goto login;
            }
        } 
        else
        {
            goto login;
        }
    }*/

    private static string GetPassword()
    {
        StringBuilder input = new StringBuilder();
        while (true)
        {
            int x = System.Console.CursorLeft;
            int y = System.Console.CursorTop;
            ConsoleKeyInfo key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                System.Console.WriteLine();
                break;
            }

            if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input.Remove(input.Length - 1, 1);
                System.Console.SetCursorPosition(x - 1, y);
                System.Console.Write(" ");
                System.Console.SetCursorPosition(x - 1, y);
            }
            else if (key.Key != ConsoleKey.Backspace)
            {
                input.Append(key.KeyChar);
                System.Console.Write("*");
            }
        }

        return input.ToString();
    }
}