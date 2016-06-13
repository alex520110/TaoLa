using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class Instance
    {
        public static T Get<T>(string classFullName)
        {
            T result;
            try
            {
                System.Type type = System.Type.GetType(classFullName);
                result = (T)((object)System.Activator.CreateInstance(type));
            }
            catch (System.Exception inner)
            {
                throw new InstanceCreateException("创建实例异常", inner);
            }
            return result;
        }
    }
}
