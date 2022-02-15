// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");
hashTableTest ht = new hashTableTest();
// ht.hashTable();
// 碰到的問題 --  集合已修改列舉作業可能尚未執行
ht.hashTableNewStudent();
Console.ReadLine();

internal class hashTableTest
{
    public void hashTable()
    {
        Hashtable ht = new Hashtable();
        ht.Add("boy", 24);
        ht.Add("girl", 25);

        foreach (DictionaryEntry num in ht)
        {
            Console.Write(num.Key);
            Console.WriteLine(num.Value);
            Console.WriteLine();
        }
    }

    public void hashTableNewStudent()
    {
        Hashtable ht = new Hashtable();
        ht.Add("boy", 24);
        ht.Add("girl", 25);

        int newStudentNum = 2;
        string htKey = "";

        Console.WriteLine("尚未加入轉學生");
        foreach (DictionaryEntry num in ht)
        {
            Console.WriteLine(num.Key + "　" + num.Value);
        }
        Console.WriteLine();

        //把Dictionary的所有key放到陣列中
        string[] keyArr = new string[ht.Keys.Count];

        //改到 List
        var keyList = new List<string>();

        int k = 0;
        foreach (string htK in ht.Keys)
        {
            //keyArr[k] = htK;
            keyList.Add(htK);
            k++;
        }

        Console.WriteLine("加入轉學生人數後");
        //利用陣列改變Dictionary的內容
        for (int i = 0; i < keyList.Count; i++)
        {
            htKey = keyList[i].ToString();
            if (htKey == "boy")
            {
                int sum = Convert.ToInt32(ht[htKey]) + newStudentNum;
                ht[htKey] = sum;
            }
            Console.WriteLine(htKey + " " + ht[htKey].ToString());
        }
    }
}