using Infrastructure.Employees.ViewModels;
using MediatR;

namespace Infrastructure.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeVm>
    {
        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
