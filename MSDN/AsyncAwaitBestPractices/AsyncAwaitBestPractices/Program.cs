using System;
using System.Threading.Tasks;

namespace AsyncAwaitBestPractices
{
    class Program
    {
        // https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming
        // https://tinyurl.com/tdc4z4hb

        static void Main()
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            try
            {
                // Asynchronous implementation.
                await Task.Delay(1000);
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                // Handle exceptions.
            }
        }
    }

    public static class DeadlockDemo
    {
        private static async Task DelayAsync()
        {
            await Task.Delay(1000);
        }
        // This method causes a deadlock when called in a GUI or ASP.NET context.
        public static void Test()
        {
            // Start the delay.
            var delayTask = DelayAsync();
            // Wait for the delay to complete.
            delayTask.Wait();
        }
    }

    public static class AsyncVoidExceptions
    {
        // Exceptions from an Async Void Method Can't Be Caught with Catch

        public static async void ThrowExceptionAsync()
        {
            throw new InvalidOperationException();
        }
        public static void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception)
            {
                // The exception is never caught here!
                throw;
            }
        }

    }


}
