using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class ImageDto
    {
        public int ImageId { get; set; }

        public string FileName { get; set; }

        public string Base64EncodedImage { get; set; }

        public int ImageOwnerId { get; set; }
    }
}
