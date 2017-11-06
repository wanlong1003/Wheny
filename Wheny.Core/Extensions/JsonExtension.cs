namespace Wheny.Core
{
    public static class JsonExtension
    {
        /// <summary>
        /// 对象转换为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerialize(this object sender)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(sender);
        }

        /// <summary>
        /// Json字符串反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(this string sender)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(sender);
        }


    }
}
