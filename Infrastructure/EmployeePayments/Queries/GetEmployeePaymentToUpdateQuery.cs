using Infrastructure.EmployeePayments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePayments.Queries
{
    public class GetEmployeePaymentToUpdateQuery : IRequest<UpdateEmployeePaymentVm>
    {
        public GetEmployeePaymentToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
