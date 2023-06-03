using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.RestaurantNetworks.Queries;
using Infrastructure.Restaurants.Queries;
using Infrastructure.Restaurants.ViewModels;
using Infrastructure.RestaurantStatuses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class GetRestaurantToUpdateQueryHandler : IRequestHandler<GetRestaurantToUpdateQuery, UpdateRestaurantVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetRestaurantToUpdateQueryHandler(DatabaseContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<UpdateRestaurantVm> Handle(GetRestaurantToUpdateQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var model =  _mapper.Map<UpdateRestaurantVm>(restaurant);

            if (restaurant.RestaurantNetworkId.HasValue)
            {
                var networkQuery = new GetRestaurantNetworkSelectListQuery(restaurant.RestaurantNetworkId.Value);
                var netWorkQueryResult = await _mediator.Send(networkQuery, cancellationToken);

                model.Networks = netWorkQueryResult;
                model.NetworkId = restaurant.RestaurantNetworkId.Value;
            }
            else
            {
                var networkQuery = new GetRestaurantNetworkSelectListQuery();
                var netWorkQueryResult = await _mediator.Send(networkQuery, cancellationToken);

                model.Networks = netWorkQueryResult;
                model.NetworkId = 0;
            }

            var statusQuery = new GetRestaurantStatusSelectListQuery(restaurant.RestaurantStatusId);
            var statusResult = await _mediator.Send(statusQuery, cancellationToken);

            model.Statuses = statusResult;
            model.StatusId = restaurant.RestaurantStatusId;

            return model;
        }
    }
}
