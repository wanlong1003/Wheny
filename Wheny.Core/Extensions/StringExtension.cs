namespace Wheny.Core
{
    /// <summary>
    /// 字符串的扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 判断当前字符串是否为空
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string sender)
        {
            return string.IsNullOrEmpty(sender);
        }

    }
}
