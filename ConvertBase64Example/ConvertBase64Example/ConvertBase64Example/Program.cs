using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ConvertBase64Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var apiKey = "test";
            string apiKeyBase64 = "testKeyBase64";

            // example string for using JSON string
            var json = System.IO.File.ReadAllText(@"C:\test1.json");

            var json2 = System.IO.File.ReadAllText(@"C:\test2.json");

            var json3 = System.IO.File.ReadAllText(@"C:\test3.json");

            //string body = JsonSerializer.Serialize(request);
            var contentMD5 = AuthorizationHelper.ToBase64MD5(json);
            var contentMD52 = AuthorizationHelper.ToBase64MD5(json2);
            var contentMD53 = AuthorizationHelper.ToBase64MD5(json3);

            Console.WriteLine($"{contentMD5}");
            Console.WriteLine($"{contentMD52}");
            Console.WriteLine($"{contentMD53}");

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

        public static string RecoverBase64StringExample(string contentMD5)
        {
            //// corect steps
            //string a = contentMD5;
            //byte[] bytes = System.Text.Encoding.GetEncoding("utf-8").GetBytes(a);

            ////編成 Base64 字串
            //string b = Convert.ToBase64String(bytes);

            var bb = Convert.FromBase64String(contentMD5);

            //從 Base64 字串還原
            string c = System.Text.Encoding.GetEncoding("utf-8").GetString(bb);

            return c;
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