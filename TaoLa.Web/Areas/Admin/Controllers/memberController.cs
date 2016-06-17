using Himall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;
using TaoLa.Web.Framework;
using TaoLa.Web.Models;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class MemberController : BaseAdminController
    {
        private IMemberService _iMemberService;

        private IRegionService _iRegionService;

        private IMemberLabelService _iMemberLabelService;

        public MemberController(IMemberService iMemberService, IRegionService iRegionService, IMemberLabelService iMemberLabelService)
        {
            this._iMemberService = iMemberService;
            this._iRegionService = iRegionService;
            this._iMemberLabelService = iMemberLabelService;
        }

        [Description("会员管理页面")]
        public ActionResult Management()
        {
            PageModel<LabelInfo> memberLabelList = this._iMemberLabelService.GetMemberLabelList(new LabelQuery());
            ((dynamic)base.ViewBag).LabelInfos = memberLabelList.Models.ToList<LabelInfo>();
            return base.View();
        }


        public JsonResult GetMemberLabel(long id)
        {
            IEnumerable<MemberLabelInfo> memberLabels = this._iMemberService.GetMemberLabels(id);
            JsonResult jsonResult = base.Json(new { Success = true, Data = memberLabels });
            return jsonResult;
        }

        public JsonResult GetMembers(bool? status, string keyWords)
        {
            IQueryable<UserMemberInfo> members = this._iMemberService.GetMembers(status, keyWords);
            var variable =
                from item in members
                select new { key = item.Id, @value = item.UserName };
            return base.Json(variable);
        }

        [Description("分页获取会员管理JSON数据")]
        public JsonResult List(int page, string keywords, int rows, long? labelid = null, bool? status = null, bool? isSeller = null, bool? isFocus = null, string regtimeStart = null, string regtimeEnd = null, string logintimeStart = null, string logintimeEnd = null)
        {
            long[] value;
            DateTime? nullable = null;
            DateTime? nullable1 = null;
            DateTime? nullable2 = null;
            DateTime? nullable3 = null;
            if (!string.IsNullOrWhiteSpace(regtimeStart))
            {
                nullable = new DateTime?(DateTime.Parse(regtimeStart));
            }
            if (!string.IsNullOrWhiteSpace(regtimeEnd))
            {
                nullable1 = new DateTime?(DateTime.Parse(regtimeEnd));
            }
            if (!string.IsNullOrWhiteSpace(logintimeStart))
            {
                nullable2 = new DateTime?(DateTime.Parse(logintimeStart));
            }
            if (!string.IsNullOrWhiteSpace(logintimeEnd))
            {
                nullable3 = new DateTime?(DateTime.Parse(logintimeEnd));
            }
            IMemberService memberService = this._iMemberService;
            MemberQuery memberQuery = new MemberQuery()
            {
                keyWords = keywords,
                Status = status,
                PageNo = page,
                PageSize = rows,
                IsSeller = isSeller,
                IsFocusWeiXin = isFocus,
                RegistTimeStart = nullable,
                RegistTimeEnd = nullable1,
                LoginTimeStart = nullable2,
                LoginTimeEnd = nullable3
            };
            MemberQuery memberQuery1 = memberQuery;
            if (labelid.HasValue)
            {
                value = new long[] { labelid.Value };
            }
            else
            {
                value = null;
            }
            memberQuery1.LabelId = value;
            PageModel<UserMemberInfo> members = memberService.GetMembers(memberQuery);
            IQueryable<MemberModel> models =
                from item in members.Models
                select new MemberModel()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    LastLoginDate = item.LastLoginDate,
                    CreateDate = item.CreateDate,
                    QQ = item.QQ,
                    Points = item.Points,
                    RealName = item.RealName,
                    Email = item.Email,
                    CellPhone = item.CellPhone,
                    Disabled = item.Disabled,
                    Nick = item.Nick
                };
            DataGridModel<MemberModel> dataGridModel = new DataGridModel<MemberModel>()
            {
                rows = models,
                total = members.Total
            };
            return base.Json(dataGridModel);
        }


        public ActionResult Detail(long id)
        {
            UserMemberInfo member = this._iMemberService.GetMember(id);
            string regionFullName = this._iRegionService.GetRegionFullName((long)member.RegionId, " ");
            MemberModel memberModel = new MemberModel()
            {
                Id = member.Id,
                UserName = member.UserName,
                LastLoginDate = member.LastLoginDate,
                QQ = member.QQ,
                Points = member.Points,
                RealName = member.RealName,
                Email = member.Email,
                Disabled = member.Disabled,
                Expenditure = member.Expenditure,
                OrderNumber = member.OrderNumber,
                CellPhone = member.CellPhone,
                CreateDate = member.CreateDate,
                Address = member.Address
            };
            MemberModel memberModel1 = memberModel;
            ((dynamic)base.ViewBag).Region = regionFullName;
            return this.PartialView("Detail", memberModel1);
        }

        public JsonResult ChangePassWord(long id, string password)
        {
            this._iMemberService.ChangePassWord(id, password);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "修改成功！"
            };
            return base.Json(result);
        }

        public JsonResult SetMemberLabel(long id, string labelids)
        {
            List<long> nums = new List<long>();
            if (!string.IsNullOrWhiteSpace(labelids))
            {
                char[] chrArray = new char[] { ',' };
                nums = (
                    from s in labelids.Split(chrArray)
                    select long.Parse(s)).ToList<long>();
            }
            this._iMemberService.SetMemberLabel(id, nums);
            return base.Json(new { Success = true });
        }

        public JsonResult SetMembersLabel(string ids, string labelids)
        {
            char[] chrArray = new char[] { ',' };
            IEnumerable<long> nums =
                from s in labelids.Split(chrArray)
                select long.Parse(s);
            chrArray = new char[] { ',' };
            IEnumerable<long> nums1 =
                from s in ids.Split(chrArray)
                select long.Parse(s);
            this._iMemberService.SetMembersLabel(nums1.ToArray<long>(), nums);
            return base.Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult BatchDelete(string ids)
        {
            string[] strArrays = ids.Split(new char[] { ',' });
            List<long> nums = new List<long>();
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                nums.Add(Convert.ToInt64(strArrays1[i]));
            }
            this._iMemberService.BatchDeleteMember(nums.ToArray());
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "批量删除成功！"
            };
            return base.Json(result);
        }

        [HttpPost]
        public JsonResult BatchLock(string ids)
        {
            string[] strArrays = ids.Split(new char[] { ',' });
            List<long> nums = new List<long>();
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                nums.Add(Convert.ToInt64(strArrays1[i]));
            }
            this._iMemberService.BatchLock(nums.ToArray());
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "批量锁定成功！"
            };
            return base.Json(result);
        }
        public JsonResult Lock(long id)
        {
            this._iMemberService.LockMember(id);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "冻结成功！"
            };
            return base.Json(result);
        }
        public JsonResult UnLock(long id)
        {
            this._iMemberService.UnLockMember(id);
            BaseController.Result result = new BaseController.Result()
            {
                success = true,
                msg = "解冻成功！"
            };
            return base.Json(result);
        }
    }
}