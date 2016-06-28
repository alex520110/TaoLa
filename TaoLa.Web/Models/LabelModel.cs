using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLa.Web.Models
{
    public class LabelModel
    {
        public long Id
        {
            get;
            set;
        }

        [MaxLength(50, ErrorMessage = "店铺名称最多50个字符")]
        [Required(ErrorMessage = "店铺名称为必填项")]
        public string LabelName
        {
            get;
            set;
        }

        public long MemberNum
        {
            get;
            set;
        }

        public LabelModel()
        {
        }
    }
}