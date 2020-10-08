using Data;

namespace Services.Interfaces
{
    // this way the controller won't know of concrete types
    public interface IImageService : ICrudService<ImagehubImage>
    {
    }
}
