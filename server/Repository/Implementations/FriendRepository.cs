using Data;
using Data.Models;

namespace Repository.Implementations
{
    public class FriendRepository : RepositoryBase<Friend, ImageHubDbContext>
    {
        public FriendRepository(ImageHubDbContext context)
          : base(context)
        {
        }
    }
}
