using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.RestaurantStatuses.ViewModels
{
    public class UpdateRestaurantStatusVm
    {
        public int Id { get; set; }
        public SelectList Status { get; set; }
        public int StatusId { get; set; }
    }
}
