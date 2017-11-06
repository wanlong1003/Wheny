using System;

namespace Wheny.Core
{
    /// <summary>
    /// 时间相关的扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 扩展DateTime类型，取得Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ToUnixTimestamp(this DateTime time)
        {
            //DateTime.MaxValue.ToUniversalTime().Ticks 一秒钟就有1000万个周期。
            return (int)((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }

        /// <summary>
        /// 扩展Double类型，将当前时间戳转换为时间
        /// </summary>
        /// <param name="unixTimestamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this double unixTimestamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimestamp);
        }

        /// <summary>
        /// 扩展Int32类型，将当前时间戳转换为时间
        /// </summary>
        /// <remarks>
        /// Int32最大支持到 2038/1/19 11:14:07
        /// </remarks>
        /// <param name="unixTimestamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int unixTimestamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimestamp);
        }
    }
}
