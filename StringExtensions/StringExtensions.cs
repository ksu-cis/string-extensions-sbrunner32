using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] {' ', '.', '?', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Capitalize(this string str)
        {
            string first = str[0].ToString().ToUpper();
            return first + str.Substring(1);
        }

        public static void Decapitalize(this string str)
        {
            // This does not work
            string first = str[0].ToString().ToLower();
            str = first + str.Substring(1);
        }

        public static string Titleize(this string title)
        {
            List<string> articles = new List<string>()
            {
                "a",
                "an",
                "the"
            };
            List<string> parts = new List<string>(title.Split(" "));
            string first = parts[0];
            if (articles.Contains(parts[0].ToLower()))
            {
                parts.RemoveAt(0);
                parts.Add(", " + first);
                first = parts[0];
                while(articles.Contains(parts[0].ToLower()))
                {
                    parts.RemoveAt(0);
                    parts.Add(" ");
                    parts.Add(first);
                    first = parts[0];
                }
               
            }
            string result = "";
            foreach (string part in parts)
            {
                result += part + " ";
            }
            return result;


        }
    }
}
