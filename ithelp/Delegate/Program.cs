using System;

namespace Delegate
{
    class Program
    {
        public delegate void DoSomething(int number);

        public delegate void DoSomething2(int number);


        public static void PrintNumber(int n)
        {
            Console.WriteLine(n);
        }

        public static void ExeDoSomething(DoSomething something)//呼叫委派的方式
        {
            something.Invoke(5);
            something(6);
        }

        public static void ExeDoSomething2(DoSomething2 something)//呼叫委派的方式
        {
            something.Invoke(5);
            something(6);
        }

        // Action action1;//無回傳值無參數
        // Action<int> action2;//無回傳值具有一個int參數
        // Action<int, string> action3;//無回傳值具有int string參數
        // Func<int> func1;//回傳int 無參數
        // Func<string, int> func2;//回傳int 具有一個string參數
        // Func<int, string, DateTime> func3;//回傳DateTime具有int string參數

        public static void ActionExeDoSomething(Action<int> something)
        {
            // 因為 PrintNumber 跟 SquareAndPrintNumber 都是符合 無回傳值 有一個int參數的方法簽章
            // 所以他們都可以當作參數傳入ExeDoSomething

            something.Invoke(5);
            something(6);
        }



        public static void SquareAndPrintNumber(int n)
        {
            n *= n;
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            // https://ithelp.ithome.com.tw/articles/10255691
            // https://dotblogs.com.tw/atowngit/2009/12/07/12311

            var something = new DoSomething(PrintNumber);
            something.Invoke(5);
            // 可簡化
            something(6);

            {
                var something2 = new DoSomething(PrintNumber);
                ExeDoSomething(something2);
            }
            {
                // 簽章一樣 只要宣告的委派不同 他們之間是不可以互相轉換的~相當的嚴謹
                var something3 = new DoSomething2(PrintNumber);
                ExeDoSomething2(something3);//error
            }

            // action 
            // 不用再寫 delegate 直接用 Action/Func
            ActionExeDoSomething(PrintNumber);
            ActionExeDoSomething(SquareAndPrintNumber);

            // 砍掉 PrintNumber
            ActionExeDoSomething((int n) =>
            {
                Console.WriteLine(n);
            });
            // 砍掉 SquareAndPrintNumber
            ActionExeDoSomething((int n) =>
            {
                n *= n;
                Console.WriteLine(n);
            });


            // 再簡化 PrintNumber
            ActionExeDoSomething(n => { Console.WriteLine(n); });
            ActionExeDoSomething(something: n => { Console.WriteLine(n); });


            Action action = null;

            for (int i = 0; i < 10; i++)
            {
                action += () => Console.WriteLine(i);
            }
            action();

            // 其實記憶體會產生10個temp 而每個temp分別就是 0-9

            Action action2 = null;

            for (int i = 0; i < 10; i++)
            {
                var temp = i;
                action2 += () => Console.WriteLine(temp);
            }
            action2();
        }
    }
}
