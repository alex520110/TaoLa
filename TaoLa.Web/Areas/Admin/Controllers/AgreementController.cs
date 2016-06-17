using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.IServices;
using TaoLa.Web.Framework;
using TaoLa.Web.Models;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class AgreementController : BaseAdminController
    {

        private ISystemAgreementService _iSystemAgreementService;

        public AgreementController(ISystemAgreementService iSystemAgreementService)
        {
            this._iSystemAgreementService = iSystemAgreementService;
        }

        public ActionResult Management()
        {
            return base.View(this.GetManagementModel(AgreementInfo.AgreementTypes.Buyers));
        }
        public AgreementModel GetManagementModel(AgreementInfo.AgreementTypes type)
        {
            AgreementModel agreementModel = new AgreementModel();
            AgreementInfo agreement = this._iSystemAgreementService.GetAgreement(type);
            agreementModel.AgreementType = agreement.AgreementType;
            agreementModel.AgreementContent = agreement.AgreementContent;
            return agreementModel;
        }

        [HttpPost]
        public JsonResult GetManagement(int agreementType)
        {
            return base.Json(this.GetManagementModel((AgreementInfo.AgreementTypes)agreementType));
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateAgreement(int agreementType, string agreementContent)
        {
            JsonResult jsonResult;
            ISystemAgreementService systemAgreementService = this._iSystemAgreementService;
            AgreementInfo agreement = systemAgreementService.GetAgreement((AgreementInfo.AgreementTypes)agreementType);
            agreement.AgreementType = agreementType;
            agreement.AgreementContent = agreementContent;
            if (!systemAgreementService.UpdateAgreement(agreement))
            {
                BaseController.Result result = new BaseController.Result()
                {
                    success = false,
                    msg = "更新协议失败！"
                };
                jsonResult = base.Json(result);
            }
            else
            {
                BaseController.Result result1 = new BaseController.Result()
                {
                    success = true,
                    msg = "更新协议成功！"
                };
                jsonResult = base.Json(result1);
            }
            return jsonResult;
        }
    }
}