using System;

namespace ExceptionInnerexceptionTostring
{
    class Program
    {
        static void Main(string[] args)
        {

            //  實戰小技巧 - .NET Exception Message、InnerException 與 ToString()
            //  https://blog.darkthread.net/blog/exception-innerexception-and-tostring/

            try
            {
                TestCase1.Test();
                TestCase2.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Example: Message");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n");
                Console.WriteLine("Example: StackTrace");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\n");
                Console.WriteLine("Example: ToString()");
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }

        
    }

    class MyCustException : ApplicationException
    {
        public MyCustException(string message,
            Exception Exception) :
            base(message, Exception)
        {
        }
    }
}
