using System.Collections.Generic;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePayments.Queries
{
    public class GetEmployeePaymentByIdQuery : IRequest<GetEmployeePaymentVm>
    {
        public GetEmployeePaymentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
