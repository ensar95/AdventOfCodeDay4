using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] sep = { "\r\n\r\n" };
            string[] text = File.ReadAllText("C:\\Users\\ensar.skopljak\\source\\repos\\AdventOfCode\\AdventOfCode\\PassportInfo.txt").Split(sep, StringSplitOptions.RemoveEmptyEntries);

            List<string> passports = text.OfType<string>().ToList(); // this isn't going to be fast.

            //for(int i = 0; i<passports.Count; i++)
            //{
            //    if(passports[i].Contains("\r") )
            //    {
            //        passports[i].Replace('\r', ' ');
            //    }
            //    if(passports[i].Contains("\n"))
            //    {
            //        passports[i].Replace('\n', ' ');
            //    }
            //}
            int counter = 0;
            for (int i = 0; i < passports.Count; i++)
            {
                if (passports[i].Contains("eyr")
                        && passports[i].Contains("hcl")
                        && passports[i].Contains("byr")
                        && passports[i].Contains("iyr")
                        && passports[i].Contains("pid")
                        && passports[i].Contains("hgt")
                        && passports[i].Contains("ecl"))
                {
                    if (IsPassportValid(passports[i]))
                    {
                        counter += 1;
                    }
                }
            }
            Console.WriteLine(counter);

        }


        private static bool IsPassportValid(string passport)
        {
            List<string> regexForPassport = new List<string>();
            string regexForByr = @"byr:(200[0-2]|19[2-9][0-9])";
            string regexForIyr = @"iyr:(2020|201[0-9])";
            string regexForEyr = @"eyr:(2030|202[0-9])";
            string regexForHgt = @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in";
            string regexForHcl = @"hcl:(#[0-9a-f]{6})";
            string regexForEcl = @"ecl:(amb|blu|brn|gry|grn|hzl|oth)";
            string regexForPid = @"pid:(\d{9}\b)";

            regexForPassport.Add(regexForIyr);
            regexForPassport.Add(regexForByr);
            regexForPassport.Add(regexForEyr);
            regexForPassport.Add(regexForHgt);
            regexForPassport.Add(regexForHcl);
            regexForPassport.Add(regexForEcl);
            regexForPassport.Add(regexForPid);

            return regexForPassport.All(reg => Regex.IsMatch(passport, reg));
        }

    }
}
