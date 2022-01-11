using System.Collections.Generic;
using System.Linq;

namespace LetKeyword
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // https://www.c-sharpcorner.com/article/overview-of-let-in-linq/

            // 1.Reading compression code
            // 2.Encapsulate functionality
            // 3.Improvement performance

            // Let is allowed only in LINQ queries, so it can't be used in Lambdas.

            var numbers = Enumerable.Range(1, 1000);

            IList<int> result = new List<int>();

            foreach (var number in numbers)
            {
                bool isEven = number % 2 == 0;

                if (isEven) result.Add(number);
            }

        }

        public static void Algo()
        {
            var numbers = Enumerable.Range(1, 1000);

            IList<int> result = (from number in numbers

                                 let isEven = number % 2 == 0

                                 where isEven
                                 select number).ToList();
        }
    }
}