using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wheny.Core
{
    /// <summary>
    /// 32位MD5加密
    ///   MD5是一种摘要算法，由于其是单向（不能解密）所以并不能称为一种加密算法，其主要用途是验证数据是否被修改
    /// </summary>
    public class MD5Encryptor
    {
        /// <summary>
        /// 加密盐（！程序生命周期内不许修改）
        /// </summary>
        private static string salt = "DRPHUBDRPHUB";

        /// <summary>
        /// 计算字符串的MD5
        /// </summary>
        /// <param name="inputString">明文</param>
        /// <param name="includeSalt">是否包含加密盐</param>
        /// <returns>MD5</returns>
        public static string String(string inputString, bool includeSalt = false)
        {
            if (includeSalt)
            {
                inputString = inputString + salt;
            }
            byte[] byteArr = Encoding.UTF8.GetBytes(inputString);
            using (MemoryStream stream = new MemoryStream(byteArr))
            {
                return Stream(stream);
            }
        }

        /// <summary>
        /// 计算Stream的MD5
        /// </summary>
        /// <param name="inputStream">原始流</param>
        /// <returns>MD5</returns>
        public static string Stream(Stream inputStream)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] byteArr = md5.ComputeHash(inputStream);
                StringBuilder sb = new StringBuilder(32);
                for (int i = 0; i < byteArr.Length; i++)
                {
                    sb.Append(byteArr[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        
    }
}
