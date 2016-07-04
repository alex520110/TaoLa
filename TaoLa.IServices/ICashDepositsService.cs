using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices.QueryModel;

namespace TaoLa.IServices
{
    public interface ICashDepositsService : IService, IDisposable
    {
        PageModel<CashDepositInfo> GetCashDeposits(CashDepositQuery query);

        PageModel<CashDepositDetailInfo> GetCashDepositDetails(CashDepositDetailQuery query);

        void AddCategoryCashDeposits(CategoryCashDepositInfo model);

        void DeleteCategoryCashDeposits(long categoryId);

        CashDepositInfo GetCashDeposit(long id);

        void AddCashDeposit(CashDepositInfo cashDeposit);

        void AddCashDepositDetails(CashDepositDetailInfo cashDepositDetail);

        CashDepositInfo GetCashDepositByShopId(long shopId);

        void UpdateEnableLabels(long id, bool enableLabels);

        decimal GetNeedPayCashDepositByShopId(long shopId);

        IEnumerable<CategoryCashDepositInfo> GetCategoryCashDeposits();

        void UpdateNeedPayCashDeposit(long categoryId, decimal CashDeposit);

        void OpenNoReasonReturn(long id);

        void CloseNoReasonReturn(long id);

        CashDepositsObligation GetCashDepositsObligation(long productId);
    }
}
