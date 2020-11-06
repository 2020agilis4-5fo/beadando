using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class ImagehubImage
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Base64EncodedImage { get; set; }

        [ForeignKey(nameof(ImageHubUser))]
        public ImageHubUser Owner { get; set; }
    }
}
