// See https://aka.ms/new-console-template for more information
using System.Net;

// https://gist.github.com/huanlin/48e44fb468011663cf33f9520259a0c6#file-ex05_asyncandthreads-cs

Log(1, "正要起始非同步工作 MyDownloadPageAsync()。");

var task = MyDownloadPageAsync("https://www.huanlintalk.com");

Log(4, "已從 MyDownloadPageAsync() 返回，但尚未取得工作結果。");

string content = await task;

Log(6, "已經取得 MyDownloadPageAsync() 的結果。");

Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);

static void Log(int num, string msg)
{
    var threadId = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine("({0}) T{1}: {2}",
        num, Thread.CurrentThread.ManagedThreadId, msg);
}

static async Task<string> MyDownloadPageAsync(string url)
{
    Log(2, "正要呼叫 WebClient.DownloadStringTaskAsync()。");

    using (var webClient = new HttpClient())
    {
        var task = webClient.GetStringAsync(url);

        Log(3, "已起始非同步工作 DownloadStringTaskAsync()。");

        string content = await task;

        Log(5, "已經取得 DownloadStringTaskAsync() 的結果。");

        return content;
    }
}