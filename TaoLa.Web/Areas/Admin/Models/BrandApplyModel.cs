using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaoLa.Web.Areas.Admin.Models
{
    public class BrandApplyModel
    {
        public string ApplyTime
        {
            get;
            set;
        }

        public int AuditStatus
        {
            get;
            set;
        }

        [Required(ErrorMessage = "品牌授权证书不能为空！")]
        public string BrandAuthPic
        {
            get;
            set;
        }

        public string BrandDesc
        {
            get;
            set;
        }

        public long BrandId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "品牌图片不能为空！")]
        public string BrandLogo
        {
            get;
            set;
        }

        [Required(ErrorMessage = "申请类型不能为空！")]
        public int BrandMode
        {
            get;
            set;
        }

        [Required(ErrorMessage = "品牌必须填写")]
        public string BrandName
        {
            get;
            set;
        }

        public long Id
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public long ShopId
        {
            get;
            set;
        }

        public string ShopName
        {
            get;
            set;
        }

        public BrandApplyModel()
        {
        }
    }
}