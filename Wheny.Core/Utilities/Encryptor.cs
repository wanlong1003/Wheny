using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wheny.Core
{
    public static class Encryptor
    {
        #region AES

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="buffer">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns>密文</returns>
        public static byte[] AESEncrypt(byte[] buffer, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                using (ICryptoTransform encryptor = provider.CreateEncryptor(key, iv))
                {
                    using (MemoryStream mstream = new MemoryStream())
                    {
                        using (CryptoStream cstream = new CryptoStream(mstream, encryptor, CryptoStreamMode.Write))
                        {
                            cstream.Write(buffer, 0, buffer.Length);
                            cstream.FlushFinalBlock();
                            return mstream.ToArray();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="buffer">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns>明文</returns>
        public static byte[] AESDecrypt(byte[] buffer, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                using (ICryptoTransform decryptor = provider.CreateDecryptor(key, iv))
                {
                    using (MemoryStream mstream = new MemoryStream())
                    {
                        using (CryptoStream cstream = new CryptoStream(mstream, decryptor, CryptoStreamMode.Write))
                        {
                            cstream.Write(buffer, 0, buffer.Length);
                            cstream.FlushFinalBlock();
                            return mstream.ToArray();
                        }
                    }
                }
            }
        }

        #endregion

        #region DES

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="buffer">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns>密文</returns>
        public static byte[] DESEncrypt(byte[] buffer, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (ICryptoTransform decryptor = provider.CreateEncryptor(key, iv))
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Write))
                        {
                            cStream.Write(buffer, 0, buffer.Length);
                            cStream.FlushFinalBlock();
                            return mStream.ToArray();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="buffer">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量</param>
        /// <returns>明文</returns>
        public static byte[] DESDecrypt(byte[] buffer, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (ICryptoTransform decryptor = provider.CreateDecryptor(key, iv))
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Write))
                        {
                            cStream.Write(buffer, 0, buffer.Length);
                            cStream.FlushFinalBlock();
                            return mStream.ToArray();
                        }
                    }
                }
            }
        }

        #endregion

        #region MD5

        /// <summary>
        /// 计算指定字符串的MD5值
        /// </summary>
        /// <param name="str">要计算其MD5的字符串</param>
        /// <returns>32位MD5值</returns>
        public static string MD5(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            return MD5(buffer);
        }

        /// <summary>
        /// 计算指定字节数组的MD5值
        /// </summary>
        /// <param name="buffer">要计算其MD5的输入</param>
        /// <returns>32位MD5值</returns>
        public static string MD5(byte[] buffer)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] byteArr = md5.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder(32);
                for (int i = 0; i < byteArr.Length; i++)
                {
                    sb.Append(byteArr[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        #endregion
    }
}
