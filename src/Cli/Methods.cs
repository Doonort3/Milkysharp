#region

using System;
using System.IO;

#endregion

namespace Milkysharp.Cli;

public class Methods
{
    public static void Write(string text, ConsoleColor fg)
    {
        System.Console.ForegroundColor = fg;
        System.Console.Write(text);
        System.Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteLine(string text, ConsoleColor fg)
    {
        System.Console.ForegroundColor = fg;
        System.Console.WriteLine(text);
        System.Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Help(string args, string syntax, string desc)
    {
        System.Console.WriteLine($"# Arguments: {args}\n" +
                                 $"# Suntax: {syntax}\n" +
                                 $"# Description: {desc}");
    }

    public static string ToTmp(string content)
    {
        File.Create(@"0:\var\tmp\tmp.tmp");
        File.WriteAllText(@"0:\var\tmp\tmp.tmp", content);
        return File.ReadAllText(@"0:\var\tmp\tmp.tmp");
    }
}