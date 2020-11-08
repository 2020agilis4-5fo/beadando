using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public partial class UserRole : IdentityRole<int>
    {
        public string RoleName { get; set; }
    }
}
