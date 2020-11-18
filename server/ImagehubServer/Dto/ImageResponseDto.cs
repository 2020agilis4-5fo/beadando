
namespace Imagehub.Core.Dto
{
    public class ImageResponseDto
    {
        public int Id { get; set; }
        public string Base64EncodedImage { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Username { get; set; }
    }
}
