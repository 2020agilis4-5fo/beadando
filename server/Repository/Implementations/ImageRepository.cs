using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
