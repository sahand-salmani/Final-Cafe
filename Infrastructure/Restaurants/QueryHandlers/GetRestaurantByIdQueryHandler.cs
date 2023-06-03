using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Restaurants.Queries;
using Infrastructure.Restaurants.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, GetRestaurantVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantByIdQueryHandler(DatabaseContext context,
                                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetRestaurantVm> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants
                .AsNoTracking()
                .Include(e => e.Contract)
                .ThenInclude(e => e.Employee)
                .Include(e => e.Contract)
                .ThenInclude(e => e.ContractPayments)
                .Include(e => e.Stants)
                .Include(e => e.RestaurantMeetings)
                .Include(e => e.RestaurantContacts)
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (restaurant == null)
            {
                return null;
            }


            var model = _mapper.Map<GetRestaurantVm>(restaurant);


            var status = await _context.RestaurantStatus.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == restaurant.RestaurantStatusId, cancellationToken);
            model.Status = status.Name;


            if (restaurant.RestaurantNetworkId.HasValue)
            {
                var network =
                    await _context.RestaurantNetworks.FirstOrDefaultAsync(e => e.Id == restaurant.RestaurantNetworkId,
                        cancellationToken);

                model.Network = network.Name;
            }
            else
            {
                model.Network = "Yoxdur";
            }

            var totalPayment = restaurant.Contract.Sum(e => e.Payment);
            var debts = restaurant.Contract.Select(e => e.ContractPayments.Sum(c => c.Amount)).Sum();
            model.TotalDebt = totalPayment - debts;

            return model;


        }
    }
}
