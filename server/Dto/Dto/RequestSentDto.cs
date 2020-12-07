using System.Collections.Generic;

namespace Common.Dto
{
    public class RequestSentDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Recipients { get; set; }
    }
}
