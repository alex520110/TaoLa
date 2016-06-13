using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    internal class DefaultContainerForDictionary : IinjectContainer
    {
        private static System.Collections.Generic.IDictionary<System.Type, object> objectDefine = new System.Collections.Generic.Dictionary<System.Type, object>();

        public void RegisterType<T>()
        {
            if (!DefaultContainerForDictionary.objectDefine.ContainsKey(typeof(T)))
            {
                DefaultContainerForDictionary.objectDefine[typeof(T)] = System.Activator.CreateInstance(typeof(T));
            }
        }

        public T Resolve<T>()
        {
            if (DefaultContainerForDictionary.objectDefine.ContainsKey(typeof(T)))
            {
                return (T)((object)DefaultContainerForDictionary.objectDefine[typeof(T)]);
            }
            throw new System.Exception("该服务未在框架中注册");
        }
    }
}
