#region

using System.IO;
using Cosmos.HAL;

#endregion

namespace Milkysharp.SystemMain
{
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
                                catch
                                {
                                    // Go to kernel back
                                }
                            else if (tempChoice.Trim(' ').ToLower() == "off")
                                try
                                {
                                    File.WriteAllText(@"0:\system\config\autologin.mcf", "off");
                                }
                                catch
                                {
                                    // Go to kernel back
                                }
                            else
                                try
                                {
                                    System.Console.WriteLine("Default. On.");
                                    File.WriteAllText(@"0:\system\config\autologin.mcf", "on");
                                }
                                catch
                                {
                                    // Go to kernel back
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
                        catch
                        {
                            System.Console.WriteLine("Kernel panic!");
                            System.Console.ReadKey();
                            Power.ACPIReboot();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }
                }
                else if (!Directory.Exists(@"0:\system\config"))
                {
                    try
                    {
                        Directory.CreateDirectory(@"0:\system\config");
                        goto start;
                    }
                    catch
                    {
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }
                }
                else
                {
                    System.Console.WriteLine("Kernel panic!");
                    System.Console.ReadKey();
                    Power.ACPIReboot();
                }
            }
            else if (!Directory.Exists(@"0:\system"))
            {
                try
                {
                    Directory.CreateDirectory(@"0:\system");
                    goto start;
                }
                catch
                {
                    System.Console.WriteLine("Kernel panic!");
                    System.Console.ReadKey();
                    Power.ACPIReboot();
                }
            }
            else
            {
                System.Console.WriteLine("Kernel panic!");
                System.Console.ReadKey();
                Power.ACPIReboot();
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
                    {
                        try
                        {
                            File.WriteAllText(@"0:\system\config\user.mcf", $"{username}:{password}");
                        }
                        catch
                        {
                            // Go to kernel back
                        }
                    }
                    else if (!File.Exists(@"0:\system\config\user.mcf"))
                    {
                        try
                        {
                            File.Create(@"0:\system\config\user.mcf");
                        }
                        catch
                        {
                            // Go to kernel back
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Kernel panic!");
                        System.Console.ReadKey();
                        Power.ACPIReboot();
                    }
                }
                else if (!Directory.Exists(@"0:\system\config"))
                {
                    try
                    {
                        Directory.CreateDirectory(@"0:\system\config");
                    }
                    catch
                    {
                        // Go to kernel back
                    }
                }
                else
                {
                    System.Console.WriteLine("Kernel panic!");
                    System.Console.ReadKey();
                    Power.ACPIReboot();
                }
            }
            else if (!Directory.Exists(@"0:\system"))
            {
                try
                {
                    Directory.CreateDirectory(@"0:\system");
                }
                catch
                {
                    // Go to back kernel
                }
            }
            else
            {
                System.Console.WriteLine("Kernel panic!");
                System.Console.ReadKey();
                Power.ACPIReboot();
            }

            return true;
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
}