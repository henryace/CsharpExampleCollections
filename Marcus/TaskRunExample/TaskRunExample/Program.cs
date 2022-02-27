using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRunExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://tinyl.io/55HA
            // https://marcus116.blogspot.com/2019/02/net-taskrun-taskfactorystartnew.html

            // Task.Factory.StartNew
            Task.Factory.StartNew(() => doSomething());

            // Task Run
            Task.Run(() => doSomething());
        }
        private static void doSomething()
        {
            Console.WriteLine($"Thread Number #{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
