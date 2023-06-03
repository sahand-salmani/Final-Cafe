using Infrastructure.EmployeeFaults.ViewModels;
using MediatR;

namespace Infrastructure.EmployeeFaults.Queries
{
    public class GetEmployeeFaultToUpdateQuery : IRequest<UpdateEmployeeFaultVm>
    {
        public GetEmployeeFaultToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
