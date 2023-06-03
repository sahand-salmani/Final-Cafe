using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class BlackList : BaseEntity
    {
        [Required,MaxLength(255)]
        public string Restaurant { get; set; }
        [Required, MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Manager { get; set; }
    }
}
