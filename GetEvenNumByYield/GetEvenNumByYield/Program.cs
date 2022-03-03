// See https://aka.ms/new-console-template for more information
using GetEvenNumByYield;
using System.Diagnostics;

var myList = new List<int>();
for (var i = 0; i < 10000000; i++)
{
    myList.Add(i);
}

var timeList = new List<long>();
for (var i = 0; i < 10; i++)
{
    var sum = 0;
    var sw = new Stopwatch();
    sw.Start();
    //var list = EvenNumByYield.getEvenNumByYield(myList);
    var list = EvenNumByYield.getEvenNumByLinq(myList);
    //var list = EvenNumByYield.getEvenNumByTemp(myList);
    foreach (var l in list)
    {
        sum += l;
    }

    // Reuse collection
    foreach (var l in list)
    {
        sum -= l;
    }
    sw.Stop();
    timeList.Add(sw.ElapsedMilliseconds);
    Console.WriteLine("Exe time: {0} ms", sw.ElapsedMilliseconds);
}
Console.WriteLine("Average: {0} ms", (double)timeList.Sum() / 10);
Console.WriteLine("Memory Usage: {0}", Process.GetCurrentProcess().PrivateMemorySize64);

//getEvenNumByYield
//Average: 340.2 ms
//Memory Usage: 157204480

// getEvenNumByLinq
// Average: 168.6 ms
// Memory Usage: 136978432

// getEvenNumByTemp
// Average: 189.9 ms
// Memory Usage: 187572224

// Time getEvenNumByLinq < getEvenNumByTemp < getEvenNumByYield
// Space getEvenNumByLinq < getEvenNumByTemp < getEvenNumByYield