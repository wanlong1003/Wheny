using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheny.Core
{
    /// <summary>
    /// 定义一个存储单例的容器
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        /// <summary>
        /// 存储所有单例的字典
        /// </summary>
        private static Dictionary<Type, object> _container;
        static Singleton()
        {
            if (_container == null)
            {
                _container = new Dictionary<Type, object>();
            }
        }

        /// <summary>
        /// 取得单例实体
        /// </summary>
        public static T Instance
        {
            get
            {
                var type = typeof(T);
                if (!_container.ContainsKey(type))
                {
                    _container.Add(type, new T());
                }
                return _container[type] as T;
            }
        }

    }
}
