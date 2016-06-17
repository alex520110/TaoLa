using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.IServices.QueryModel;

namespace TaoLa.IServices
{
    public interface IMemberService : IService, IDisposable
    {

        string GetLogo();

        UserMemberInfo Register(string username, string password, string mobile = "", long introducer = 0L);

        UserMemberInfo Register(string username, string password, string serviceProvider, string openId, string headImage = null, long introducer = 0L, string nickname = null, string unionid = null);

        UserMemberInfo Register(OAuthUserModel model);

        UserMemberInfo QuickRegister(string username, string realName, string nickName, string serviceProvider, string openId, string headImage = null, MemberOpenIdInfo.AppIdTypeEnum appidtype = MemberOpenIdInfo.AppIdTypeEnum.Normal, string unionid = null, string unionopenid = null);

        void BindMember(long userId, string serviceProvider, string openId, string headImage = null, string unionid = null, string unionopenid = null);

        void BindMember(long userId, string serviceProvider, string openId, MemberOpenIdInfo.AppIdTypeEnum AppidType, string headImage = null, string unionid = null);

        void BindMember(OAuthUserModel model);

        bool CheckMemberExist(string username);

        bool CheckMobileExist(string mobile);

        void UpdateMember(UserMemberInfo memeber);

        long UpdateShareUserId(long id, long shareUserId, long shopId = 0L);

        void UpdateDistributionUserLink(IEnumerable<long> ids, long userId);

        void ChangePassWord(long id, string password);

        void LockMember(long id);

        void UnLockMember(long id);

        void DeleteMember(long id);

        void BatchDeleteMember(long[] ids);

        void BatchLock(long[] ids);

        PageModel<UserMemberInfo> GetMembers(MemberQuery query);

        IQueryable<UserMemberInfo> GetMembers(bool? status, string keyWords);

        UserMemberInfo GetMember(long id);

        UserMemberInfo Login(string username, string password);

        UserMemberInfo GetMemberByName(string userName);

        UserMemberInfo GetUserByCache(long id);

        UserCenterModel GetUserCenterModel(long id);

        UserMemberInfo GetMemberByOpenId(string serviceProvider, string openId);

        UserMemberInfo GetMemberByUnionId(string serviceProvider, string UnionId);

        void DeleteMemberOpenId(long userid, string openid);

        UserMemberInfo GetMemberByContactInfo(string contact);

        void CheckContactInfoHasBeenUsed(string serviceProvider, string contact, MemberContactsInfo.UserTypes userType = MemberContactsInfo.UserTypes.General);

        IQueryable<MemberLabelInfo> GetMembersByLabel(long labelid);

        IEnumerable<MemberLabelInfo> GetMemberLabels(long memid);

        void SetMemberLabel(long userid, IEnumerable<long> labelids);

        void SetMembersLabel(long[] userid, IEnumerable<long> labelids);

        IEnumerable<int> GetAllTopRegion();
    }
}
