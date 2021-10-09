using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetCurrentMethod
{
    class Program
    {
        private static string GetException(MethodBase methodBase, Exception e)
        {
            StackTrace trace = new StackTrace(e);
            StackFrame previousFrame = null;

            foreach (StackFrame frame in trace.GetFrames())
            {
                if (frame.GetMethod() == methodBase)
                {
                    break;
                }

                previousFrame = frame;
            }

            return previousFrame?.GetMethod().Name;
        }

        private static void CallForException()
        {
            DoActualException();
        }

        private static void DoActualException()
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            // 目前執行方法的類別名稱
            Console.WriteLine($"GetCurrentMethod.Name : {MethodBase.GetCurrentMethod().Name}");
            // 目前執行方法的命名空間
            Console.WriteLine($"GetCurrentMethod.DeclaringType.Namespace : {MethodBase.GetCurrentMethod().DeclaringType.Namespace}");
            // 目前執行方法的全名
            Console.WriteLine($"GetCurrentMethod.DeclaringType.FullName : {MethodBase.GetCurrentMethod().DeclaringType.FullName}");

            try
            {
                CallForException();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Method Name : {0} ", GetException(MethodBase.GetCurrentMethod(), e));
            }

            Console.ReadKey();
        }
    }
}
