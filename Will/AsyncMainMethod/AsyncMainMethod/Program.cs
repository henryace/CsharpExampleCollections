using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncMainMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                using (var http = new HttpClient())
                {
                    const string url = "http://docs.microsoft.com/";
                    var body = await http.GetStringAsync(url);
                    Console.WriteLine($"Size: {body.Length}");
                }
            }).Wait();
        }
    }
}
