using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaoLa.Web.Models
{
    public class MemberModel : UserMemberInfo
    {
        public string StrCreateDate
        {
            get
            {
                return base.CreateDate.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public string StrLastLoginDate
        {
            get
            {
                return base.LastLoginDate.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public MemberModel()
        {
        }
    }
}