using Infrastructure.EmployeePunishments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePunishments.Queries
{
    public class GetEmployeePunishmentToUpdateQuery : IRequest<EditEmployeePunishmentVm>
    {
        public GetEmployeePunishmentToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
