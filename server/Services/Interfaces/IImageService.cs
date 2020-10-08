using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    // this way the controller won't know of concrete types
    public interface IImageService : ICrudService<ImagehubImage>
    {
    }
}
