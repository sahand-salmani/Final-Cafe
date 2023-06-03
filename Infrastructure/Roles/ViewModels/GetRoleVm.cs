using System.Collections.Generic;
using Domain.Users;

namespace Infrastructure.Roles.ViewModels
{
    public class GetRoleVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUserRole> Users { get; set; } = new List<ApplicationUserRole>();
    }
}
