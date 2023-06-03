using System.Collections.Generic;
using Domain.Models;

namespace Infrastructure.Restaurants.ViewModels
{
    public class GetRestaurantVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int RestaurantStatusId { get; set; }
        public string Status { get; set; }
        public string Network { get; set; }
        public decimal TotalDebt { get; set; }
        public List<Contract> Contract { get; set; }
        public List<RestaurantContact> RestaurantContacts { get; set; }
        public List<RestaurantMeeting> RestaurantMeetings { get; set; }
    }
}
