using Microsoft.AspNetCore.Identity;

namespace Data.Models
{
    public partial class UserRole : IdentityRole<int>
    {
        public string RoleName { get; set; }
    }
}
