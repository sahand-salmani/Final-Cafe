using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Users.ViewModels
{
    public class EditUserRoleVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> RoleId { get; set; } = new List<string>();
        public MultiSelectList SelectList { get; set; }
    }
}
