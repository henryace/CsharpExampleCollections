using System;
using System.Linq;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "123456789";
            Console.WriteLine(StringExtensionOne.Reverse(s));

            Console.WriteLine(s.ReverseExtension());

            int[] ints = { 10, 45, 15, 39, 21, 26 };
            var result = ints.OrderBy(g => g);
            foreach (var i in result)
            {
                System.Console.Write(i + " ");
            }

            string s2 = "Hello Extension Methods";
            int i2 = s2.WordCount();
        }
    }
}
