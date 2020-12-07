using Data;
using Data.Models;

namespace Repository.Implementations
{
    public class ImageRepository : RepositoryBase<ImagehubImage, ImageHubDbContext>
    {
        public ImageRepository(ImageHubDbContext context)
            :base(context)
        {
        }
    }
}
