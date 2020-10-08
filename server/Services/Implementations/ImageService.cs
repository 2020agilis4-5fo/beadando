using Data;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
