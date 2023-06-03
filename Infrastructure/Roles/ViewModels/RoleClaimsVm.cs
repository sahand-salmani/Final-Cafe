using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Roles.ViewModels
{
    public class RoleClaimsVm
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string> ClaimsValues { get; set; } = new List<string>();
        public MultiSelectList Claims { get; set; }
    }
}
