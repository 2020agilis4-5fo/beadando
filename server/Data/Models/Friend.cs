using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public partial class Friend
    {
        public int LeftId { get; set; }
        public int RightId { get; set; }
        public ImageHubUser Left { get; set; }
        public ImageHubUser Right { get; set; }
    }
}
