using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Common;
using DataAccess.Pagination;
using Infrastructure.Common;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePayments.Queries
{
    public class GetEmployeePaymentByMonthQuery : IRequest<List<MonthlyEmployeePaymentVm>>
    {
        public GetEmployeePaymentByMonthQuery(int id)
        {
            Id = id;
            var now = DateTime.Now.ToAzDateTime();
            StartDate = new DateTime(now.Year, 1, 1);
            EndDate = new DateTime(now.Year, 12, 30);
        }
        public GetEmployeePaymentByMonthQuery(int id, DateTime startDate, DateTime endDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
