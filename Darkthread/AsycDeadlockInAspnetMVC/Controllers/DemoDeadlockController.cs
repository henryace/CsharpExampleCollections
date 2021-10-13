using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsycDeadlockInAspnetMVC.Controllers
{
    public class DemoDeadlockController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage DownloadPage()
        {
            // https://www.huanlintalk.com/2016/01/asyc-deadlock-in-aspbet.html


            var task = MyDownloadPageAsync("https://www.huanlintalk.com");

            // 也就是控制流會停在那裡，等到非同步工作完成並返回，才能繼續往下執行
            var content = task.Result;

            return Request.CreateResponse($"網頁長度: {content.Length}");
        }

        private static HttpClient _httpClient = new HttpClient();

        private async Task<string> MyDownloadPageAsync(string url)
        {
            var task = _httpClient.GetStringAsync(url);
            // 這裡會獲取當前的 SynchronizationContext 
            string content = await task; // 這裡在 task 完成後，會 deadlock!
            return content;
        }
    }
}