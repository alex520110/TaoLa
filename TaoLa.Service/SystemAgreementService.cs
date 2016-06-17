using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices;

namespace TaoLa.Service
{
    public class SystemAgreementService : ServiceBase, ISystemAgreementService, IService, IDisposable
    {
        public SystemAgreementService()
        {
        }

        public void AddAgreement(AgreementInfo model)
        {
            this.context.AgreementInfo.Add(model);
            this.context.SaveChanges();
        }

        public AgreementInfo GetAgreement(AgreementInfo.AgreementTypes type)
        {
            AgreementInfo agreementInfo = (
                from b in this.context.AgreementInfo
                where b.AgreementType == (int)type
                select b).FirstOrDefault<AgreementInfo>();
            return agreementInfo;
        }

        public bool UpdateAgreement(AgreementInfo model)
        {
            bool flag;
            AgreementInfo agreement = this.GetAgreement((AgreementInfo.AgreementTypes)model.AgreementType);
            agreement.AgreementType = model.AgreementType;
            agreement.AgreementContent = model.AgreementContent;
            agreement.LastUpdateTime = DateTime.Now;
            flag = (this.context.SaveChanges() <= 0 ? false : true);
            return flag;
        }
    }
}
