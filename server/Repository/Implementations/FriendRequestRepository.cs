using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
