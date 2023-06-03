using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.UserToken.ViewModels
{
    public class CreateUserTokenVm
    {
        [Required, MaxLength(20)]
        [Remote(action:"CheckTokenExists", controller:"UserManagement", areaName:"Panel")]
        public string Token { get; set; }
        [Required, MaxLength(255)]
        public string RoleId { get; set; }
        public SelectList Roles { get; set; }

    }
}
