using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheny.Core
{
    public enum ValidateCodeType
    {
        /// <summary>
        /// 纯数值
        /// </summary>
        Number,

        /// <summary>
        /// 数值与字母的组合
        /// </summary>
        NumberAndLetter,

        /// <summary>
        /// 汉字
        /// </summary>
        Hanzi
    }
}
