using Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFriendService
    {
        Task<FriendRequest> SendFriendRequest(FriendRequest req);
        Task<Friend> AcceptFriendRequest(FriendRequest req);
        Task CancelFriendRequest(FriendRequest req);
        Task Unfriend(Friend connection);
        IQueryable<ImageHubUser> GetFriendList(int id);
        IQueryable<ImageHubUser> GetUsersWhomFriendRequestSentBy(int id);
        IQueryable<ImageHubUser> GetUsersWhomFriendRequestSentTo(int id);
    }
}
