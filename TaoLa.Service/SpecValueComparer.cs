using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Service
{
    public class SpecValueComparer : IEqualityComparer<SpecificationValueInfo>
    {
        public SpecValueComparer()
        {
        }

        public bool Equals(SpecificationValueInfo x, SpecificationValueInfo y)
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

        public int GetHashCode(SpecificationValueInfo spec)
        {
            int num;
            num = (!object.ReferenceEquals(spec, null) ? spec.Value.GetHashCode() : 0);
            return num;
        }
    }
}
