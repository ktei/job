using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleResult
{
    class Program
    {
        static void Main(string[] args)
        {
            string httpResult = File.ReadAllText(@"F:\Dev\google_result.html");
            //string pattern = "www.infotrack.com.au";
            string pattern = "\\<h3 class=\"r\"\\>\\<a href=\"http://www\\.infotrack\\.com\\.au";
            Console.WriteLine(CountStringOccurrences(httpResult, pattern));
            Console.ReadLine();
        }

        public static int CountStringOccurrences(string text, string pattern)
        {

            return Regex.Matches(text, pattern).Count;

            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}
