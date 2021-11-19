using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace LetKeyword.Tests
{
    [TestClass]
    public class ImprovementPerformanceTests
    {
        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void ImprovementPerformance_WithLet()
        {
            var result = from shop in ShoppingDB.GetShops()

                         let myAverage = shop.Sales.Average(a => a.Amount)

                         where myAverage > 1000
                            && myAverage < 100000

                         select new
                         {
                             Id = shop.Id,
                             Name = shop.Name,
                             Sales = shop.Sales,
                             SalesAverage = myAverage
                         };
        }

        [TestMethod]
        public void ImprovementPerformance_WithoutLet()
        {
            var result = from shop in ShoppingDB.GetShops()

                         where shop.Sales.Average(a => a.Amount) > 1000
                            && shop.Sales.Average(a => a.Amount) < 100000

                         select new
                         {
                             Id = shop.Id,
                             Name = shop.Name,
                             Sales = shop.Sales,
                             SalesAverage = shop.Sales.Average(a => a.Amount)
                         };
        }

        [TestMethod]
        public void ImprovementPerformance_WithoutLet3()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var data = Enumerable.Range(0, 30000 - 1).ToList();

            var result = (from s in data

                          where data.Average(a => a) > s
                             && data.Average(a => a) < 100

                          select new
                          {
                              Number = s,
                              Average = data.Average(a => a)
                          }).ToList();

            stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}");
        }

        [TestMethod]
        public void ImprovementPerformance_WithLet4()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var data = Enumerable.Range(0, 30000 - 1).ToList();

            var result = (from s in data

                          let average = data.Average(a => a)

                          where average > s
                             && average < 100

                          select new
                          {
                              Number = s,
                              Average = average
                          }).ToList();

            stopWatch.Stop();

            System.Diagnostics.Trace.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds}");
        }
    }
}