using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Service
{
    public class AttrValueComparer : IEqualityComparer<AttributeValueInfo>
    {
        public AttrValueComparer()
        {
        }

        public bool Equals(AttributeValueInfo x, AttributeValueInfo y)
        {
            bool flag;
            if (!object.ReferenceEquals(x, y))
            {
                flag = ((object.ReferenceEquals(x, null) ? false : !object.ReferenceEquals(y, null)) ? x.Value == y.Value : false);
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public int GetHashCode(AttributeValueInfo attr)
        {
            int num;
            num = (!object.ReferenceEquals(attr, null) ? attr.Value.GetHashCode() : 0);
            return num;
        }
    }
}
