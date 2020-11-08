using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class FriendImagesListDto
    {
        public int UserId { get; set; }
        public IList<ImageResponseDto> FriendImages { get; set; }
    }
}
