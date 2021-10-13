using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionInnerexceptionTostring
{
    //
    // 摘要:
    //     Represents errors that occur during application execution.
    public static class TestCase1
    {
        public static void Test()
        {
            try
            {
                InnerCall();
            }
            catch (Exception ex)
            {
                throw new MyCustException(
                    "出錯了!",
                    ex);
            }
        }

        static void InnerCall()
        {
            try
            {
                InnerTwoCall();
            }
            catch (Exception ex)
            {
                throw new MyCustException(
                    "出錯了!",
                    ex);
            }
        }

        static void InnerTwoCall()
        {
            try
            {
                InnerThree();
            }
            catch (Exception ex)
            {
                throw new MyCustException(
                "出錯了!",
                ex);
            }
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
