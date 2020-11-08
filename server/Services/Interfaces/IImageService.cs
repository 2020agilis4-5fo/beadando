using Data;
using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    // this way the controller won't know of concrete types
    public interface IImageService : ICrudService<ImagehubImage>
    {
        Task<IEnumerable<ImagehubImage>> GetFriendImages(int requestedUserId);
    }
}
