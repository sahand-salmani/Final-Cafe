using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class GetLeastTimeRemainingMeetingsQuery : IRequest<List<RestaurantMeeting>>
    {

    }

}
