using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Users.ViewModels
{
    public class ChangePasswordVm
    {
        public string Id { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Daxil etdiyiniz şifrə eyni deyil")]
        public string ConfirmPassword { get; set; }
    }
}
