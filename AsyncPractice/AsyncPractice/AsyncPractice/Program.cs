﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // https://ithelp.ithome.com.tw/articles/10257485
            // C＃ Task 十分鐘輕鬆學同步非同步

            //創建4條子線程

            Task subThread1 = new Task(() =>
            {
                //這裡可以填入一系列要讓該線程做的事
                Thread.Sleep(1000);
                Console.WriteLine("I am subThread1!");
            });
            Task subThread2 = new Task(() =>
            {
                //這裡可以填入一系列要讓該線程做的事
                Thread.Sleep(1000);
                Console.WriteLine("I am subThread2!");
            });
            Task subThread3 = new Task(() =>
            {
                //這裡可以填入一系列要讓該線程做的事
                Thread.Sleep(1000);
                Console.WriteLine("I am subThread3!");
            });
            Task subThread4 = new Task(() =>
            {
                //這裡可以填入一系列要讓該線程做的事
                Thread.Sleep(1000);
                Console.WriteLine("I am subThread4!");
            });

            // 讓線程溝通

            // 讓2條線程開始跑
            subThread2.Start();
            subThread1.Start();
            // GetAwaiter() : 等待完成, OnCompleted() : 線程完成後要做的事
            subThread1.GetAwaiter().OnCompleted(() =>
            {
                // 線程完成後要做的事
                // 讓2條線程開始跑, 當第一條線程跑完
                subThread4.Start();
                subThread3.Start();
            });
            // GetAwaiter() : 等待完成, GetResult() : 取得結果
            // 實際寫法範例 result =  subThread2.GetAwaiter().GetResult(); (這裡只是因為沒有回傳才這樣寫)
            subThread2.GetAwaiter().GetResult();
            // 等待線程完成才繼續往下走
            subThread3.Wait();
            subThread4.Wait();
        }
    }
}