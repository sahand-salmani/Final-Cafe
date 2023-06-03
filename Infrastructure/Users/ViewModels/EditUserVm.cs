using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Users.ViewModels
{
    public class EditUserVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public MultiSelectList Roles { get; set; }
        public List<string> RoleIds { get; set; } = new List<string>();
    }
}
