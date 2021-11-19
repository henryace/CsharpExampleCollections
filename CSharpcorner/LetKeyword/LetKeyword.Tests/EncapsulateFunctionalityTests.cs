using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LetKeyword.Tests
{
    [TestClass]
    public class EncapsulateFunctionalityTests
    {
        [TestMethod]
        public void EncapsulateFunctionality_WithLet()
        {
            var result = from shop in ShoppingDB.GetShops()

                         let myAverage = shop.Sales.Average(a => a.Amount)

                         where myAverage > 1000
                            && myAverage < 100000

                         select shop;
        }

        [TestMethod]
        public void EncapsulateFunctionality_WithoutLet()
        {
            var result = from shop in ShoppingDB.GetShops()

                         where shop.Sales.Average(a => a.Amount) > 1000
                            && shop.Sales.Average(a => a.Amount) < 100000

                         select shop;
        }
    }
}