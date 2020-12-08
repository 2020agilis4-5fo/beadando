namespace Common.Dto
{
    public class ImageUploadDto
    {
        public string Base64EncodedImage { get; set; }
        public string ImageNameWithExtension { get; set; }
        public int OwnerId { get; set; }
        public string Username { get; set; }
    }
}
