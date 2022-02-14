using System;
using System.Linq;
using System.Text;

namespace Substring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "0123456789";
            int startIndex = 7;
            int endIndex = str.Length - 1;
            //string title = str.Substring(startIndex, endIndex);
            //Console.WriteLine(title);

            var theString = "ABCDEF10456";
            var sb = new StringBuilder();
            for (int i = 0; i < theString.Length; i++)
            {
                //if (Enumerable.Range(3, 3).Contains(i))
                //{
                //    Console.WriteLine(i);
                //}

                sb.Append((3 < i && i <= 6) ? "#" : theString[i]);
            }
            theString = sb.ToString(); //theString: "ABrDEF"
            Console.WriteLine(theString);
        }
    }
}