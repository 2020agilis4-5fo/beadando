using System.Collections.Generic;

namespace Common.Dto
{
    public class FriendListDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Friends { get; set; }
    }
}
