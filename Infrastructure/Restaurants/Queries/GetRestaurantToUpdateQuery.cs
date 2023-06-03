using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Restaurants.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantToUpdateQuery : IRequest<UpdateRestaurantVm>
    {
        public GetRestaurantToUpdateQuery(int id)
        {
            Id = id;
        }

        public GetRestaurantToUpdateQuery(int id, int networkId)
        {
            Id = id;
            NetworkId = networkId;
        }
        public int Id { get; set; }
        public int NetworkId { get; set; }
    }
}
