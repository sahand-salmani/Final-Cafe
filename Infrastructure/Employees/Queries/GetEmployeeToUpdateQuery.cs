using Infrastructure.Employees.ViewModels;
using MediatR;

namespace Infrastructure.Employees.Queries
{
    public class GetEmployeeToUpdateQuery : IRequest<EditEmployeeVm>
    {
        public GetEmployeeToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
