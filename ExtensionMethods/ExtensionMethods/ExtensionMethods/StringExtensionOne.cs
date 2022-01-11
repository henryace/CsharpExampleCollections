using System;

namespace ExtensionMethods
{
    // static class is required
    public static class StringExtensionOne
    {
        // 字串反轉
        // using static method
        public static string Reverse(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";
            char[] charArray = new char[s.Length];
            int len = s.Length - 1;
            for (int i = 0; i <= len; i++)
            {
                charArray[i] = s[len - i];
            }
            return new string(charArray);
        }

        // 字串反轉
        // using static method
        public static string ReverseExtension(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";
            char[] charArray = new char[s.Length];
            int len = s.Length - 1;
            for (int i = 0; i <= len; i++)
            {
                charArray[i] = s[len - i];
            }
            return new string(charArray);
        }
    }

    public static class MSDNMyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
