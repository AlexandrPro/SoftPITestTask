using System;
using System.Text.RegularExpressions;

namespace LogParser.Parsers
{
    public class LogStringParser
    {
        public  static string[] Split(string str)
        {
            string pattern = @"([\d\.]+)\s-\s-\s" + //IP Adress
                @"\[([^\]]+)\]\s" +                 //Date and time
                "\"" + @"([\w]+)\s" +               //HTTP method
                @"([^\s?]+)" + "[^\"]+\"" +         //file path and name
                @"\s(\d{3})\s" +                    //HTTP status
                @"([\d]+)\s";                       //size of file

            try
            {
                Match match = Regex.Matches(str, pattern)[0];
                if (match.Length == 0) throw new ArgumentException("String \"" + str + "\" has not correct structure!");
                
                string[] strs = new string[match.Length];
                for (int i = 0; i < match.Length; i++)
                {
                    strs[i] = match.Groups[i + 1].Value;
                }

                strs[1] = ToDateTimeOffsetFormat(strs[1]);
                return strs;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ОШИБКА!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Возникла при попытке разобрать строку:");
                Console.WriteLine(str);
                return null;
            }
        }

        static private string ToDateTimeOffsetFormat(string str)
        {
            //заменить первое двоеточие на пробле и привести это "+0300" к этому "+3" (последнее не точно) 
            Regex rgx = new Regex(":");
            str = rgx.Replace(str, " ", 1);

            return str;
        }
        
    }
}
