using System;
using System.ComponentModel;
using System.Linq;

namespace Wheny.Core
{
    /// <summary>
    /// 枚举类型的扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 取得枚举的描述信息，如果该枚举值没有DescriptionAttribute则返回枚举值
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            var attributes = (DescriptionAttribute[])e.GetType().GetMember(e.ToString()).FirstOrDefault().GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Count() > 0)
            {
                return attributes.First().Description;
            }
            else
            {
                return e.ToString();
            }
        }
    }
}
