﻿namespace SimpleISO7064.Examples
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("SimpleISO7064 Examples application started...");

            try
            {
                var results = new[]
                {
                    "1011000026831187407",
                    "G123489654321Y",
                    "9999123456789012141490",
                    "BAISDLAFKBM",
                    "ISO793W"
                }.Select(v => {
                    bool isMod11Radix2Valid;
                    try
                    {
                        isMod11Radix2Valid = Iso7064.PureSystem.Mod11Radix2.IsValid(v);
                    }
                    catch
                    {
                        isMod11Radix2Valid = false;
                    }
                    bool isMod37Radix2Valid;
                    try
                    {
                        isMod37Radix2Valid = Iso7064.PureSystem.Mod37Radix2.IsValid(v);
                    }
                    catch
                    {
                        isMod37Radix2Valid = false;
                    }
                    bool isMod97Radix10Valid;
                    try
                    {
                        isMod97Radix10Valid = Iso7064.PureSystem.Mod97Radix10.IsValid(v);
                    }
                    catch
                    {
                        isMod97Radix10Valid = false;
                    }
                    bool isMod661Radix26Valid;
                    try
                    {
                        isMod661Radix26Valid = Iso7064.PureSystem.Mod661Radix26.IsValid(v);
                    }
                    catch
                    {
                        isMod661Radix26Valid = false;
                    }
                    bool isMod1271Radix36Valid;
                    try
                    {
                        isMod1271Radix36Valid = Iso7064.PureSystem.Mod1271Radix36.IsValid(v);
                    }
                    catch
                    {
                        isMod1271Radix36Valid = false;
                    }
                    return new
                    {
                        Value = v,
                        IsMod11Radix2Valid = isMod11Radix2Valid,
                        IsMod37Radix2Valid = isMod37Radix2Valid,
                        IsMod97Radix10Valid = isMod97Radix10Valid,
                        IsMod661Radix26Valid = isMod661Radix26Valid,
                        IsMod1271Radix36Valid = isMod1271Radix36Valid
                    };
                });
                Console.WriteLine(
                    "Value \t\t\t Mod11Radix2 \t Mod37Radix2 \t Mod97Radix10 \t Mod661Radix26 \t Mod1271Radix36");
                foreach(var result in results)
                {
                    Console.WriteLine(
                        $"{result.Value.PadRight(22)} \t {result.IsMod11Radix2Valid} \t\t {result.IsMod37Radix2Valid} \t\t {result.IsMod97Radix10Valid} \t\t {result.IsMod661Radix26Valid} \t\t {result.IsMod1271Radix36Valid}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    string.Concat("An unhandled exception has been thrown", Environment.NewLine, e.ToString()));
            }
            finally
            {
                Console.WriteLine("Application ended. Press <enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}