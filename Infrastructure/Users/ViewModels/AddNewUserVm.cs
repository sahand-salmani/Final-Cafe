using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Users.ViewModels
{
    public class AddNewUserVm
    {
        [Required, MinLength(3), MaxLength(50)]
        //[Remote(controller: "UserManagement", action: "CheckUserNameExists", areaName: "Panel")]
        public string UserName { get; set; }

        [Required, MinLength(5), MaxLength(50), DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "E-mail is not valid")]
        [Remote(controller:"UserManagement", action: "CheckUserEmailExists", areaName:"Panel")]
        public string Email { get; set; }

        [Required, MinLength(5), MaxLength(50), DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "E-mail is not valid")]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50),
         DataType(DataType.Password), Compare(nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }

        [MaxLength(10), Required]
        public string Token { get; set; }
    }
}
