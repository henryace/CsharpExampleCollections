using System;
using System.Collections.Generic;
using System.Linq;

namespace PartitionList
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.delftstack.com/zh-tw/howto/csharp/list-to-string-in-csharp/

            int x = 30;

            NewMethod(x);
            NewMethod2(x);
        }

        private static void NewMethod(int inpu)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            int x = 30;
            List<int> input = new List<int>() { 1, 2, 7, 33, 23, 88 };

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < x)
                {
                    leftList = leftList.Append(input[i]).ToList();
                }
                else
                {
                    rightList = rightList.Append(input[i]).ToList();

                }
            }
            leftList.AddRange(rightList);
            string joinedList = String.Join(", ", leftList.ToArray());
            Console.WriteLine(joinedList);
        }

        private static void NewMethod2(int inpu)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            int x = 30;
            List<int> input = new List<int>() { 1, 2, 7, 33, 23, 88 };

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < x)
                {
                    leftList.Add(input[i]);
                }
                else
                {
                    rightList.Add(input[i]);

                }
            }
            leftList.AddRange(rightList);
            string joinedList = String.Join(", ", leftList.ToArray());
            Console.WriteLine(joinedList);
        }
    }
}
