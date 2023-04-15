#region

using System;
using System.IO;
using Cosmos.HAL;
using Milkysharp.Cli;
using Milkysharp.Screens;

#endregion

namespace Milkysharp.SystemMain;

internal class Recovery
{
    public static bool NewValueForAutologinConfig()
    {
        start:
        if (Directory.Exists(@"0:\system"))
        {
            if (Directory.Exists(@"0:\system\config"))
            {
                if (File.Exists(@"0:\system\config\autologin.mcf"))
                {
                    var regulAutologin = File.ReadAllText(@"0:\system\config\autologin.mcf");

                    if (string.IsNullOrEmpty(regulAutologin) && string.IsNullOrWhiteSpace(regulAutologin))
                    {
                        System.Console.WriteLine("Write a new value to the autologin config. on/off");
                        var tempChoice = System.Console.ReadLine();
                        if (tempChoice.Trim(' ').ToLower() == "on")
                            try
                            {
                                File.WriteAllText(@"0:\system\config\autologin.mcf", "on");
                            }
                            catch (Exception e)
                            {
                                Crush.CrushScreen(e);
                            }
                        else if (tempChoice.Trim(' ').ToLower() == "off")
                            try
                            {
                                File.WriteAllText(@"0:\system\config\autologin.mcf", "off");
                            }
                            catch (Exception e)
                            {
                                Crush.CrushScreen(e);
                            }
                        else
                            try
                            {
                                System.Console.WriteLine("Default. On.");
                                File.WriteAllText(@"0:\system\config\autologin.mcf", "on");
                            }
                            catch (Exception e)
                            {
                                Crush.CrushScreen(e);
                            }
                    }
                }
                else if (!File.Exists(@"0:\system\config\autologin.mcf"))
                {
                    try
                    {
                        File.Create(@"0:\system\config\autologin.mcf");
                        goto start;
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
            }
            else if (!Directory.Exists(@"0:\system\config"))
            {
                try
                {
                    Directory.CreateDirectory(@"0:\system\config");
                    goto start;
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
        }
        else if (!Directory.Exists(@"0:\system"))
        {
            try
            {
                Directory.CreateDirectory(@"0:\system");
                goto start;
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

    public static bool WriteUserDataToUserConfig(string username, string password)
    {
        if (Directory.Exists(@"0:\system"))
        {
            if (Directory.Exists(@"0:\system\config"))
            {
                if (File.Exists(@"0:\system\config\user.mcf"))
                    try
                    {
                        File.WriteAllText(@"0:\system\config\user.mcf", $"{username}:{password}");
                    }
                    catch (Exception e)
                    {
                        Crush.CrushScreen(e);
                    }
                else if (!File.Exists(@"0:\system\config\user.mcf"))
                    try
                    {
                        File.Create(@"0:\system\config\user.mcf");
                    }
                    catch (Exception e)
                    {
                        Crush.CrushScreen(e);
                    }
                else
                    Crush.CrushScreenWithoutException();
            }
            else if (!Directory.Exists(@"0:\system\config"))
            {
                try
                {
                    Directory.CreateDirectory(@"0:\system\config");
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
        }
        else if (!Directory.Exists(@"0:\system"))
        {
            try
            {
                Directory.CreateDirectory(@"0:\system");
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

    public static void HardReset()
    {
        System.Console.Clear();
        Directory.Delete(@"0:\system", true);
        Directory.Delete(@"0:\home", true);
        File.Delete(@"0:\var\tmp\temp.tmp");
        Power.CPUReboot();
    }

    public static void RecoverySystemDirs()
    {
        System.Console.Clear();
        System.Console.BackgroundColor = ConsoleColor.DarkBlue;
        System.Console.ForegroundColor = ConsoleColor.White;
        System.Console.Clear();

        Methods.WriteLine("Recovery Systems Directories program.", ConsoleColor.Yellow);

        if (!Directory.Exists(@"0:\system"))
            try
            {
                MethodsInfo.ConsoleError("system dir. attempt to correct");

                Directory.CreateDirectory(@"0:\system");

                MethodsInfo.ConsoleOk("system dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\system")) MethodsInfo.ConsoleOk("system dir");

        if (!Directory.Exists(@"0:\system\config"))
            try
            {
                MethodsInfo.ConsoleError("system\\config dir. attempt to correct");

                Directory.CreateDirectory(@"0:\system\config");

                MethodsInfo.ConsoleOk("system\\config dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\system\config")) MethodsInfo.ConsoleOk("system\\config dir");

        if (!Directory.Exists(@"0:\home\"))
        {
            try
            {
                MethodsInfo.ConsoleError("home dir. attempt to correct");

                //Cli.Methods.WriteLine("\nEnter a new name for the user folder.", ConsoleColor.White);
                //string reconveryUsername = System.Console.ReadLine();

                //if (!string.IsNullOrEmpty(reconveryUsername))
                //{
                Directory.CreateDirectory(@"0:\home");
                // Directory.CreateDirectory(@$"0:\home\{reconveryUsername}");

                MethodsInfo.ConsoleOk("home dir");
                MethodsInfo.ConsoleOk("user folder");
                //} 
                //else if (string.IsNullOrEmpty(reconveryUsername))
                //{
                // Cli.Methods.WriteLine("User. Default", ConsoleColor.DarkYellow);
                //}
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        }
        else if (Directory.Exists(@"0:\home\"))
        {
            MethodsInfo.ConsoleOk("home dir");
            MethodsInfo.ConsoleOk("user folder");
        }

        if (!Directory.Exists(@"0:\usr"))
            try
            {
                MethodsInfo.ConsoleError("usr dir. attempt to correct.");

                Directory.CreateDirectory(@"0:\usr");

                MethodsInfo.ConsoleOk("usr dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\usr")) MethodsInfo.ConsoleOk("usr dir");

        if (!Directory.Exists(@"0:\usr\bin"))
            try
            {
                MethodsInfo.ConsoleError("usr\\bin dir. attempt to correct");

                Directory.CreateDirectory(@"0:\usr\bin");

                MethodsInfo.ConsoleOk("usr\\bin dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\usr\bin")) MethodsInfo.ConsoleOk("usr\\bin dir");

        if (!Directory.Exists(@"0:\var"))
            try
            {
                MethodsInfo.ConsoleError("var dir. attempt to correct");

                Directory.CreateDirectory(@"0:\var");

                MethodsInfo.ConsoleOk("var dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\var")) MethodsInfo.ConsoleOk("var dir");

        if (!Directory.Exists(@"0:\var\log"))
            try
            {
                MethodsInfo.ConsoleError("var\\log dir. attempt to correct");

                Directory.CreateDirectory(@"0:\var\log");

                MethodsInfo.ConsoleOk("var\\log dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\var\log")) MethodsInfo.ConsoleOk("var\\log dir");

        if (!Directory.Exists(@"0:\var\tmp"))
            try
            {
                MethodsInfo.ConsoleError("var\\tmp dir. attempt to correct");

                Directory.CreateDirectory(@"0:\var\tmp");

                MethodsInfo.ConsoleOk("var\\tmp dir");
            }
            catch (Exception e)
            {
                Crush.CrushScreen(e);
            }
        else if (Directory.Exists(@"0:\var\tmp")) MethodsInfo.ConsoleOk("var\\tmp dir");

        MethodsInfo.ConsoleInfo("Complete... Press any key...");
        System.Console.ReadKey();
        Configurator.Init();

        // пиздец это полный нахуй
        /* if (systemDir == true)
        {
            if (systemConfigDir == true)
            {
                if (homeDir == true)
                {
                    if (usrDir == true)
                    {
                        if (usrBinDir == true)
                        {
                            if (varDir == true)
                            {
                                if (varLogDir == true)
                                {
                                    if (varTmpDir == true)
                                    {
                                        Core.Kernel.SetupStatus = false;
                                        Configurator.Init();
                                    }
                                    else
                                    {
                                        goto tmp;
                                    }
                                } 
                                else
                                {
                                    goto log;
                                }
                            }
                            else
                            {
                                goto var;
                            }
                        } 
                        else
                        {
                            goto bin;
                        }
                    } 
                    else
                    {
                        goto usr;
                    }
                }
                else
                {
                    goto home;
                }
            }
            else
            {
                goto config;
            }

        } 
        else
        {
            goto system;
        }*/
    }

    /*public static bool ReinstallMilkysharp()
    {
        bool systemSkip = false;
        bool homeSkip = false;
        bool varSkip = false;
        bool binSkip = false;
        bool usrSkip = false;

        if (Directory.Exists(@"0:\system"))
        {
            if (Directory.Exists(@"0:\home"))
            {
                if (Directory.Exists(@"0:\var"))
                {
                    if (Directory.Exists(@"0:\usr"))
                    {
                        if (Directory.Exists(@"0:\bin"))
                        {
                            try
                            {
                                Console.Clear();
                                if (!systemSkip)
                                {
                                    Directory.Delete(@"0:\system", true);
                                }
                                if (!homeSkip)
                                {
                                    Directory.Delete(@"0:\home", true);
                                }
                                if (!varSkip)
                                {
                                    Directory.Delete(@"0:\var", true);
                                }
                                if (!usrSkip)
                                {
                                    Directory.Delete(@"0:\urs", true);
                                }
                                if (!binSkip)
                                {
                                    Directory.Delete(@"0:\bin", true);
                                }
                                Cosmos.HAL.Power.CPUReboot();
                            }
                            catch
                            {
                                return false;
                            }
                        }
                        else if (!Directory.Exists(@"0:\bin"))
                        {
                            Console.WriteLine(@"Skip 0:\bin");
                            binSkip = true;
                        }
                    }
                    else if (!Directory.Exists(@"0:\usr"))
                    {
                        Console.WriteLine(@"Skip 0:\usr");
                        usrSkip = true;
                    }
                }
                else if (!Directory.Exists(@"0:\var"))
                {
                    Console.WriteLine(@"Skip 0:\var");
                    varSkip = true;
                }
            }
            else if (!Directory.Exists(@"0:\home"))
            {
                Console.WriteLine(@"Skip 0:\system");
                homeSkip = true;

            }
        } 
        else if (!Directory.Exists(@"0:\system"))
        {
            Console.WriteLine(@"Skip 0:\system");
            systemSkip = true;
        }

        return true;
    }*/
}