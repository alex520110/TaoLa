using Himall.Entity;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices;
using TaoLa.IServices.QueryModel;

namespace TaoLa.Service
{
    public class MemberLabelService : ServiceBase, IMemberLabelService, IService, IDisposable
    {
        public MemberLabelService()
        {
        }

        public void AddLabel(LabelInfo model)
        {
            this.context.LabelInfo.Add(model);
            this.context.SaveChanges();
        }

        public void DeleteLabel(LabelInfo model)
        {
            LabelInfo labelInfo = this.context.LabelInfo.FirstOrDefault<LabelInfo>((LabelInfo e) => e.Id == model.Id);
            this.context.LabelInfo.Remove(labelInfo);
            this.context.SaveChanges();
        }

        public LabelInfo GetLabel(long id)
        {
            LabelInfo labelInfo = this.context.LabelInfo.FirstOrDefault<LabelInfo>((LabelInfo item) => item.Id == id);
            return labelInfo;
        }

        public PageModel<LabelInfo> GetMemberLabelList(LabelQuery model)
        {
            IQueryable<LabelInfo> page = this.context.LabelInfo.AsQueryable<LabelInfo>();
            if (!string.IsNullOrWhiteSpace(model.LabelName))
            {
                page =
                    from item in page
                    where item.LabelName.Contains(model.LabelName)
                    select item;
            }
            int num = 0;
            if ((model.PageNo <= 0 ? false : model.PageSize > 0))
            {
                page = page.GetPage<LabelInfo>(out num, model.PageNo, model.PageSize, null);
            }
            return new PageModel<LabelInfo>()
            {
                Models = page,
                Total = num
            };
        }

        public void UpdateLabel(LabelInfo model)
        {
            LabelInfo labelName = this.context.LabelInfo.FirstOrDefault<LabelInfo>((LabelInfo e) => e.Id == model.Id);
            labelName.LabelName = model.LabelName;
            this.context.SaveChanges();
        }
    }
}
