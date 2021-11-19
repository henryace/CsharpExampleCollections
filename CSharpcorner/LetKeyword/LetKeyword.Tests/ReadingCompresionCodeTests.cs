using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace LetKeyword.Tests
{
    [TestClass]
    public class ReadingCompresionCodeTests
    {
        [TestMethod]
        public void ReadingCompressionCode_WithLet()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = from shop in ShoppingDB.GetShops()

                         let hasMarchSales = shop.Sales.Any(s => s.Date.Month == 3)
                         let hasPairSales = shop.Sales.Count() % 2 == 0

                         where hasMarchSales && hasPairSales

                         select shop;

            stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}");
        }

        [TestMethod]
        public void ReadingCompressionCode_WithoutLet()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = from shop in ShoppingDB.GetShops()

                         where shop.Sales.Any(s => s.Date.Month == 3)
                            && shop.Sales.Count() % 2 == 0

                         select shop;

            stopWatch.Stop();

            // Check Run time in test
            System.Diagnostics.Trace.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}");
        }
    }
}