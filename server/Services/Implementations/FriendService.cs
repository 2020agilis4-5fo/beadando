using AutoMapper;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly ICrudRepository<FriendRequest> _friendReqRepo;
        private readonly ICrudRepository<Friend> _friendRepo;
        private readonly IMapper _mapper;
        public FriendService(ICrudRepository<FriendRequest> friendReqRepo,
            ICrudRepository<Friend> friendRepo, IMapper mapper)
        {
            _friendRepo = friendRepo;
            _friendReqRepo = friendReqRepo;
            _mapper = mapper;
        }
        public async Task<Friend> AcceptFriendRequest(FriendRequest req)
        {
            var request = await _friendReqRepo.GetElementsAsync()
                .Where(r => r.ToId == req.FromId && r.FromId == req.ToId)
                .FirstOrDefaultAsync();
            if (request == null)
            {
                throw new ApplicationException("The friend request cannot be found");
            }

            var friend = _mapper.Map<Friend>(request);
            await _friendRepo.CreateAsync(friend);
            await _friendReqRepo.DeleteAsync(request);
            return friend;
        }

        public async Task CancelFriendRequest(FriendRequest req)
        {
            var request = await _friendReqRepo.GetElementsAsync()
               .Where(r => r.ToId == req.FromId && r.FromId == req.ToId)
               .FirstOrDefaultAsync();
            if (request == null)
            {
                throw new ApplicationException("The friend request cannot be found");
            }

            await _friendReqRepo.DeleteAsync(request);
        }

        public IQueryable<ImageHubUser> GetFriendList(int id)
        {
            var rights = _friendRepo.GetElementsAsync()
                .Where(f => f.LeftId == id)
                .Include(f => f.Right)
                .Select(f => f.Right);

            var lefts = _friendRepo.GetElementsAsync()
                .Where(f => f.RightId == id)
                .Include(f => f.Left)
                .Select(f=>f.Left);

            // todo: is distinct needed?

            return rights.Concat(lefts);
        }

        public IQueryable<ImageHubUser> GetUsersWhomFriendRequestSentBy(int id)
        {
            // s/he sent it
            // todo: is distinct needed?
            return _friendReqRepo.GetElementsAsync()
                .Where(f => f.FromId == id).Select(f => f.To);         
        }

        public IQueryable<ImageHubUser> GetUsersWhomFriendRequestSentTo(int id)
        {
            // s/he received it
            // todo: is distinct needed?
            return _friendReqRepo.GetElementsAsync()
                .Where(f => f.ToId == id).Select(f => f.From);
        }

        public async Task<FriendRequest> SendFriendRequest(FriendRequest req)
        {
            var request = await _friendReqRepo.GetElementAsync(req.Id);
            if (request != null)
            {
                throw new ApplicationException("Friend request already sent");
            }

            await _friendReqRepo.CreateAsync(req);
            return req;
        }

        public async Task Unfriend(Friend connection)
        {
            var friend = await _friendRepo.GetElementsAsync()
                .Where(f => f.LeftId == connection.LeftId && f.RightId == connection.RightId ||
                f.RightId == connection.LeftId && f.LeftId == connection.RightId)
                .SingleOrDefaultAsync();

            // todo: is distinct needed?
            if (friend == null)
            {
                throw new ApplicationException("You are not friends");
            }

            await _friendRepo.DeleteAsync(friend);
        }

    }
}
