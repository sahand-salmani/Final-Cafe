using System.Collections.Generic;

namespace Infrastructure.Users.ViewModels
{
    public class GetUserVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<UserRoleVm> UserRoles { get; set; }
    }
}
