using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices.QueryModel;

namespace TaoLa.IServices
{
    public interface IMemberLabelService : IService, IDisposable
    {
        void AddLabel(LabelInfo model);

        void DeleteLabel(LabelInfo model);

        void UpdateLabel(LabelInfo model);

        LabelInfo GetLabel(long id);

        PageModel<LabelInfo> GetMemberLabelList(LabelQuery model);
    }
}
