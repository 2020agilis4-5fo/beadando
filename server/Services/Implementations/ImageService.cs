using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ImageService : CrudServiceBase<ImagehubImage>, IImageService
    {
        private readonly IFriendService _friendService;

        public ImageService(ICrudRepository<ImagehubImage> repository, IFriendService friendService)
            :base(repository)
        {
            _friendService = friendService;
        }

        public async Task<IEnumerable<ImagehubImage>> GetFriendImages(int requestedUserId)
        {
            var friends = _friendService.GetFriendList(requestedUserId).Select(f => f.Id);
            return await _repo.GetElementsAsync()
                .Where(img => friends.Contains(img.OwnerId))
                .ToListAsync();
        }
    }
}
