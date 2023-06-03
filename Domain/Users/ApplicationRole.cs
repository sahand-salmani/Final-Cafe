using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> Users { get; set; }

        [Required, Range(1, byte.MaxValue), DefaultValue(2)]
        public byte Rank { get; set; }
    }
}
