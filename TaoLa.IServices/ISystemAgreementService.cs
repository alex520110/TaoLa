using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface ISystemAgreementService : IService, IDisposable
    {
        AgreementInfo GetAgreement(AgreementInfo.AgreementTypes type);

        void AddAgreement(AgreementInfo model);

        bool UpdateAgreement(AgreementInfo model);
    }
}
