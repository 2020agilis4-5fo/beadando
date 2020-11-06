using Data;
using Data.Models;

namespace Services.Interfaces
{
    // this way the controller won't know of concrete types
    public interface IImageService : ICrudService<ImagehubImage>
    {
    }
}
