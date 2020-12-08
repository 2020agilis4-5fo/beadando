namespace Common.Dto
{
    public class ImageDto
    {
        public int ImageId { get; set; }

        public string FileName { get; set; }

        public string Base64EncodedImage { get; set; }

        public int ImageOwnerId { get; set; }
    }
}
