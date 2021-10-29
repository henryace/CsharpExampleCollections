using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace ConvertBase64Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var apiKey = "test";
            string apiKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKey));

            Console.WriteLine("Hello World!");

            // example string for using JSON string
            string temp =
                @"{""test"":""test""}";

            var contentMD5 = AuthorizationHelper.ToBase64MD5(temp);

            using (var client = new System.Net.Http.HttpClient())
            {
                // set request headers
                client.DefaultRequestHeaders.Clear();

                // custom Authorization should use TryAddWithoutValidation method
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "authorization");

                // TryAddWithoutValidation("Content-MD5", contentMD5) will return false in ASP.NET MVC5
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-MD5", contentMD5);

                // Construct an HttpContent from the data
                HttpContent httpContent = new StringContent(temp);

                // set Content-MD5 in ASP.NET MVC5
                httpContent.Headers.ContentMD5 = Convert.FromBase64String(contentMD5);

                // Example for convert base64 string
                ConvertRecoverBase64StringExample(contentMD5);
            }
        }

        private static void ConvertRecoverBase64StringExample(string contentMD5)
        {
            // corect steps
            string a = contentMD5;
            byte[] bytes = System.Text.Encoding.GetEncoding("utf-8").GetBytes(a);

            //編成 Base64 字串
            string b = Convert.ToBase64String(bytes);

            var bb = Convert.FromBase64String(b);

            //從 Base64 字串還原
            string c = System.Text.Encoding.GetEncoding("utf-8").GetString(bb);
        }
    }

    public static class AuthorizationHelper
    {
        /// <summary>
        ///  Returns the MD5 encrypted data in Base64 format
        /// </summary>
        /// <param name="data">The string to be encrypt</param>
        /// <returns></returns>
        public static string ToBase64MD5(string data)
        {
            return Convert.ToBase64String(MD5(Encoding.UTF8.GetBytes(data)));
        }

        /// <summary>
        /// Returns the MD5 encrypted data in Lower Case Hex format
        /// </summary>
        /// <param name="data">The string to be encrypt</param>
        /// <returns></returns>
        public static string ToLowerCaseHexMD5(string data)
        {
            var value = MD5(Encoding.UTF8.GetBytes(data));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            foreach (var val in value)
            {
                builder.Append(val.ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Returns the MD5 encrypted data as a byte array
        /// </summary>
        /// <param name="data">Data to be encrypted</param>
        /// <returns>MD5 encrypted data</returns>
        public static byte[] MD5(byte[] data)
        {
            var md5Crp = new MD5CryptoServiceProvider();
            return md5Crp.ComputeHash(data);
        }

        /// <summary>
        ///  Compute Sign
        /// </summary>
        /// <param name="merchantId">merchantId</param>
        /// <param name="platformGroupCode">platformGroupCode</param>
        /// <param name="timeStamp">timeStamp</param>
        /// <param name="contentMD5">contentMD5</param>
        /// <returns>sign</returns>
        public static string ComputeSignHMACSHA256(string contentMD5, string apiKeyBase64)
        {
            // 24 byte

            var stringToSign = "‽" + contentMD5 + "‽";

            var hmacSha = new HMACSHA256 { Key = Convert.FromBase64String(apiKeyBase64) };
            var hashBytes = hmacSha.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
            // return sign
            return Convert.ToBase64String(hashBytes);
        }
    }
}