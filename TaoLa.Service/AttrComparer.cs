using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Service
{
    public class AttrComparer : IEqualityComparer<AttributeInfo>
    {
        public AttrComparer()
        {
        }

        public bool Equals(AttributeInfo x, AttributeInfo y)
        {
            bool flag;
            if (object.ReferenceEquals(x, y))
            {
                flag = true;
            }
            else if ((object.ReferenceEquals(x, null) ? false : !object.ReferenceEquals(y, null)))
            {
                flag = (x.Id != y.Id || x.Id == (long)0 ? false : y.Id != (long)0);
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public int GetHashCode(AttributeInfo attr)
        {
            int num;
            num = (!object.ReferenceEquals(attr, null) ? (int)(attr.Id ^ attr.TypeId) : 0);
            return num;
        }
    }
}
