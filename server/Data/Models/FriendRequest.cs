using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public partial class FriendRequest
    {
        [ForeignKey(nameof(ImageHubUser)), Required]
        public int FromId { get; set; }
        public ImageHubUser From { get; set; }

        [ForeignKey(nameof(ImageHubUser)), Required]
        public int ToId { get; set; }
        public ImageHubUser To { get; set; }
    }
}
