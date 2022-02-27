using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitWiseOperation
{
    public class Operation
    {
        public static int NumberOf1(int n)
        {
            var count = 0;
            int flag = 1;

            while (flag > 0)
            {
                if((n & flag) > 0)
                    count++;

                flag = flag << 1;
            }

            return count;
        }
    }
}
