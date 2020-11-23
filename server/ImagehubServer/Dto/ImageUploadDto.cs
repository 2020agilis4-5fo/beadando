using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core.Dto
{
    public class ImageUploadDto
    {
        public string Base64EncodedImage { get; set; }
        public string ImageNameWithExtension { get; set; }
        public int OwnerId { get; set; }
        public string Username { get; set; }
    }
}
