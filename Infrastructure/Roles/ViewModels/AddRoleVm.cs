using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Roles.ViewModels
{
    public class AddRoleVm
    {
        [Required, MinLength(3), MaxLength(50)]
        [Remote(controller: "RoleManagement", action: "CheckRoleNameExists", areaName: "Panel")]
        public string RoleName { get; set; }
    }
}
