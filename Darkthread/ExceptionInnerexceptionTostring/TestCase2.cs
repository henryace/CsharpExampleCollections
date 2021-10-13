using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionInnerexceptionTostring
{
    public static class TestCase2
    {
        public static void Test()
        {
            //都沒有寫 catch 最後還是會抓到錯誤?
            try
            {
                InnerCall();
            }
            //catch (Exception ex)
            //{
            //    throw new MyCustException(
            //        "出錯了!",
            //        ex);
            //}
            finally
            {
                Console.WriteLine("test");
            }
        }

        static void InnerCall()
        {
            InnerTwoCall();
            //try
            //{
            //    InnerTwoCall();
            //}
            ////catch (Exception ex)
            ////{
            ////    throw new MyCustException(
            ////        "出錯了!",
            ////        ex);
            ////}
            //finally
            //{
            //    Console.WriteLine("test");
            //}
        }

        static void InnerTwoCall()
        {
            try
            {
                InnerThree();
            }
            //catch (Exception ex)
            //{
            //    throw new MyCustException(
            //    "出錯了!",
            //    ex);
            //}
            finally
            {
                throw new ArgumentException("InnerTwoCall 出錯了，明知故犯");
            }

        }

        static void InnerThree()
        {
            return;
        }
    }
}
