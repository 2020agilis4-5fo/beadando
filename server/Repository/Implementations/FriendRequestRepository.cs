using Data;
using Data.Models;

namespace Repository.Implementations
{
    public class FriendRequestRepository  : RepositoryBase<FriendRequest, ImageHubDbContext>
    {
        public FriendRequestRepository(ImageHubDbContext context)
          : base(context)
        {
        }
    }
}
