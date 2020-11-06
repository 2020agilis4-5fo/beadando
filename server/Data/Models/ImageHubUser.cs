using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public partial class ImageHubUser : IdentityUser<int>
    {
        [NotMapped]
        public ICollection<ImagehubImage> UserImages { get; set; }
    }
}
