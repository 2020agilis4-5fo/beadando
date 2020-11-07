using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class RequestReceivedDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Senders { get; set; }
    }
}
