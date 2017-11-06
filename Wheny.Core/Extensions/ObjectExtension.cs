namespace Wheny.Core
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 对象转换为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object sender)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(sender);
        }
    }
}
