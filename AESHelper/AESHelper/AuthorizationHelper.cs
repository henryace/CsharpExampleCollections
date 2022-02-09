using System;
using System.Security.Cryptography;
using System.Text;

namespace AuthorizationHelper
{
    public static class AES
    {
        private const string _encryptIv = "tool";

        // TODO: use key depends on environment
        private const string _envProduction = "testKey";

        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="data">需加密字串</param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            //TODO:要因環境變數取不同的key做解密
            var passPhrase = _envProduction;
            //var passPhrase = Constants.Encrypt.Environment.Production;
            var iv = _encryptIv;
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("data");
            }
            var dataBytes = Encoding.UTF8.GetBytes(data);

            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Key = PassPhraseDerivedBytes(passPhrase, 256);
            aes.IV = IvDerivedBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            var resultBytes = crypto.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

            return Convert.ToBase64String(resultBytes, 0, resultBytes.Length);
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="data">需解密字串</param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            //TODO:要因環境變數取不同的key做解密
            var passPhrase = _envProduction;
            //var passPhrase = Constants.Encrypt.Environment.Production;
            var iv = _encryptIv;
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("data");
            }
            var dataBytes = Convert.FromBase64String(data);

            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Key = PassPhraseDerivedBytes(passPhrase, 256);
            aes.IV = IvDerivedBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            var resultBytes = crypto.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

            return Encoding.UTF8.GetString(resultBytes, 0, resultBytes.Length);
        }

        /// <summary>
        /// Get the IV bytes
        /// </summary>
        /// <param name="iv">Initialization Vector</param>
        /// <returns></returns>
        private static byte[] IvDerivedBytes(string iv)
        {
            return Encoding.UTF8.GetBytes(iv.PadLeft(20, 'F').Substring(2, 16));
        }

        /// <summary>
        /// Get the Pass Phrase bytes
        /// </summary>
        /// <param name="passPhrase">密钥</param>
        /// <param name="keySize">Size of the key</param>
        /// <returns></returns>
        private static byte[] PassPhraseDerivedBytes(string passPhrase, int keySize)
        {
            return keySize switch
            {
                256 => ShaHelper.Hash256(passPhrase),
                512 => ShaHelper.Hash512(passPhrase),
                _ => throw new InvalidOperationException($"Invalid key size: {keySize}.")
            };
        }

        private class ShaHelper
        {
            /// <summary>
            /// Protected constructor
            /// </summary>
            protected ShaHelper()
            { }

            /// <summary>
            /// SHA 512 Hash
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static byte[] Hash512(string text)
            {
                var hashedString = Encoding.UTF8.GetBytes(text);

                using var sha = SHA512.Create();
                var data = sha.ComputeHash(hashedString);

                return data;
            }

            /// <summary>
            /// SHA 256 Hash
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static byte[] Hash256(string text)
            {
                var hashedString = Encoding.UTF8.GetBytes(text);

                using var sha = SHA256.Create();
                var data = sha.ComputeHash(hashedString);

                return data;
            }
        }
    }
}