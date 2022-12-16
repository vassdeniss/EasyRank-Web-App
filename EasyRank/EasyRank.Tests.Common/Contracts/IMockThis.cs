using EasyRank.Infrastructure.Models.Accounts;

namespace EasyRank.Web.UnitTests
{
    public interface IMockThis<T>
    {
        T CreateMock(params EasyRankUser[] userList);
    }
}
