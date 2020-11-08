using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class FriendListDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Friends { get; set; }
    }
}
