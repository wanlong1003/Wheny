using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wheny.Core
{
    /// <summary>
    /// SHA256加密
    /// </summary>
    public class SHA256Encryptor
    {
        /// <summary>
        /// 加密盐
        /// </summary>
        private static readonly string salt = "DRPHUBDRPHUB";

        /// <summary>
        /// 计算字符串的SHA256
        /// </summary>
        /// <param name="inputString">明文</param>
        /// <param name="includeSalt">是否包含加密盐</param>
        /// <returns>SHA256</returns>
        public static string String(string inputString, bool includeSalt= false)
        {
            if (includeSalt)
            {
                inputString = inputString + salt;
            }
            byte[] byteArr = Encoding.Default.GetBytes(inputString);
            using (MemoryStream stream = new MemoryStream(byteArr))
            {
                return Stream(stream);
            }
        }

        /// <summary>
        /// 计算Stream的SHA256
        /// </summary>
        /// <param name="inputStream">原始流</param>
        /// <returns>SHA256</returns>
        public static string Stream(Stream inputStream)
        {
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] byteArr = sha256.ComputeHash(inputStream);
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
