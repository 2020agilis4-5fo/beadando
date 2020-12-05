using System.Collections.Generic;

namespace Common.Dto
{
    public class FriendImagesListDto
    {
        public int UserId { get; set; }
        public IList<ImageResponseDto> FriendImages { get; set; }
    }
}
