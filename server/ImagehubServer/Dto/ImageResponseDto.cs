using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class ImageResponseDto
    {
        public int Id { get; set; }
        public string Base64EncodedImage { get; set; }
        public string Name { get; set; }
    }
}
