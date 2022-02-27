using System;

namespace ExtensionMethods
{
    // static class is required
    public static class StringExtensionTwo
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

        // MSDN Example:
        //  The following example shows an extension method defined for the System.String class.
        //  It's defined inside a non-nested, non-generic static class:
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
