using System.ComponentModel.DataAnnotations;

namespace Infrastructure.BlackLists.ViewModels
{
    public class CreateBlackListVm
    {
        [Required, MaxLength(255)]
        public string Restaurant { get; set; }
        [Required, MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Manager { get; set; }
    }
}
