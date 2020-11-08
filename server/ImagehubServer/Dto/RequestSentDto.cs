using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class RequestSentDto
    {
        public int UserId { get; set; }
        public IList<UserDto> Recipients { get; set; }
    }
}
