using Data;
using Data.Models;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ImageService : CrudServiceBase<ImagehubImage>, IImageService
    {
        public ImageService(ICrudRepository<ImagehubImage> repository)
            :base(repository)
        {
        }

    }
}
