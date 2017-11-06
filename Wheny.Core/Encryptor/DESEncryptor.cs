using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wheny.Core
{
    /// <summary>
    /// DES加密
    /// </summary>
    public class DESEncryptor
    {
        //默认加密密钥
        private static string defaultEncryptKey = "DRP@@HUB";
        //默认加密向量
        private static string defaultEncryptIV = "DRP@@HUB";

        /// <summary>
        /// 使用默认密钥和向量加密字符串
        /// </summary>
        /// <param name="encryptString">明文</param>
        /// <returns>密文</returns>
        public static string EncryptDES(string encryptString)
        {
            return EncryptDES(encryptString, defaultEncryptKey, defaultEncryptIV);
        }

        /// <summary>
        /// 使用默认密钥和向量解密字符串
        /// </summary>
        /// <param name="decryptString">密文</param>
        /// <returns>明文</returns>
        public static string DecryptDES(string decryptString)
        {
            return DecryptDES(decryptString, defaultEncryptKey, defaultEncryptIV);
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <param name="encryptIV">加密向量,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey, string encryptIV)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptIV.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dcsp = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dcsp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <param name="encryptIV">解密向量，要求为8位,和加密向量一致</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey, string encryptIV)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptIV.Substring(0, 8));
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dcsp = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
