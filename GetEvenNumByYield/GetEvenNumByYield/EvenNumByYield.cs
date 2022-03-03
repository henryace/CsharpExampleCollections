using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEvenNumByYield
{
    public class EvenNumByYield
    {
        public static IEnumerable<int> getEvenNumByYield(IEnumerable<int> collection)
        {
            foreach (var i in collection)
            {
                if (i % 2 == 0) yield return i;
            }
        }

        public static IEnumerable<int> getEvenNumByLinq(IEnumerable<int> collection)
        {
            return collection.ToList().Where(i => i % 2 == 0);
        }

        public static IEnumerable<int> getEvenNumByTemp(IEnumerable<int> collection)
        {
            var temp = new List<int>();
            foreach (var i in collection)
            {
                if (i % 2 == 0) temp.Add(i);
            }
            return temp;
        }
    }
}