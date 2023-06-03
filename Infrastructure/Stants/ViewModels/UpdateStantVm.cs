using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Stants.ViewModels
{
    public class UpdateStantVm
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public SelectList SelectList { get; set; }
    }
}
