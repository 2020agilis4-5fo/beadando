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
        public ImageHubUser()
        {
            UserImages = new HashSet<ImagehubImage>();
            FriendshipsInitiatedList = new HashSet<Friend>();
            FriendshipsReceivedList = new HashSet<Friend>();
            RequestsSent = new HashSet<FriendRequest>();
            RequestsReceived = new HashSet<FriendRequest>();
        }

        [NotMapped]
        public ICollection<ImagehubImage> UserImages { get; set; }
        
        public ICollection<Friend> FriendshipsInitiatedList { get; set; }
        public ICollection<Friend> FriendshipsReceivedList { get; set; }

        public ICollection<FriendRequest> RequestsSent { get; set; }
        public ICollection<FriendRequest> RequestsReceived { get; set; }

    }
}
