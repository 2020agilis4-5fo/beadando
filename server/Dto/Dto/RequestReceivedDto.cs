using System.Collections.Generic;

namespace Common.Dto
{
    public class RequestReceivedDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Senders { get; set; }
    }
}
