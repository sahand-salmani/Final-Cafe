using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class UserRegisterToken : BaseEntity
    {
        [MaxLength(20), Required]
        public string Token { get; set; }
        [MaxLength(255), Required]
        public string RoleId { get; set; }
        public bool IsUsed { get; set; }
    }
}
