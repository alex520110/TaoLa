using Himall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using TaoLa.Web.Framework;
using TaoLa.Web.Models;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class LabelController : BaseAdminController
    {
        private IMemberLabelService _iMemberLabelService;

        private IMemberService _iMemberService;

        public LabelController(IMemberLabelService iMemberLabelService, IMemberService iMemberService)
        {
            this._iMemberLabelService = iMemberLabelService;
            this._iMemberService = iMemberService;
        }

        [Description("会员标签管理页面")]
        public ActionResult Management()
        {
            return base.View();
        }

        [Description("分页获取会员管理JSON数据")]
        public JsonResult List(int page, string keywords, int rows)
        {
            IMemberLabelService memberLabelService = this._iMemberLabelService;
            LabelQuery labelQuery = new LabelQuery()
            {
                LabelName = keywords,
                PageSize = rows,
                PageNo = page
            };
            PageModel<LabelInfo> memberLabelList = memberLabelService.GetMemberLabelList(labelQuery);
            IEnumerable<LabelModel> list =
                from item in memberLabelList.Models.ToList<LabelInfo>()
                select new LabelModel()
                {
                    MemberNum = (long)this._iMemberService.GetMembersByLabel(item.Id).Count<MemberLabelInfo>(),
                    LabelName = item.LabelName,
                    Id = item.Id
                };
            DataGridModel<LabelModel> dataGridModel = new DataGridModel<LabelModel>()
            {
                rows = list,
                total = memberLabelList.Total
            };
            return base.Json(dataGridModel);
        }

        public JsonResult deleteLabel(long Id)
        {
            if (this._iMemberService.GetMembersByLabel(Id).Count<MemberLabelInfo>() > 0)
            {
                throw new TaoLaException("标签已经在使用，不能删除！");
            }
            this._iMemberLabelService.DeleteLabel(new LabelInfo()
            {
                Id = Id
            });
            return base.Json(new { Success = true });
        }


        public ActionResult Label(long id = 0L)
        {
            LabelInfo label = this._iMemberLabelService.GetLabel(id) ?? new LabelInfo();
            LabelModel labelModel = new LabelModel()
            {
                Id = label.Id,
                LabelName = label.LabelName
            };
            return base.View(labelModel);
        }

        [HttpPost]
        public JsonResult Label(LabelModel model)
        {
            LabelInfo labelInfo = new LabelInfo()
            {
                Id = model.Id,
                LabelName = model.LabelName
            };
            LabelInfo labelInfo1 = labelInfo;
            if (labelInfo1.Id <= (long)0)
            {
                this._iMemberLabelService.AddLabel(labelInfo1);
            }
            else
            {
                this._iMemberLabelService.UpdateLabel(labelInfo1);
            }
            return base.Json(new { Success = true });
        }

    }
}