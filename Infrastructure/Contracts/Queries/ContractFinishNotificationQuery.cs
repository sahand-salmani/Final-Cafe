using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Common.Settings;
using Infrastructure.Contracts.ViewModels;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class ContractFinishNotificationQuery : IRequest<List<ContractNotificationVm>>
    {
        public ContractFinishNotificationQuery()
        {
            Days = DashboardSetting.ContractEndNotificationDay;
            Count = DashboardSetting.ContractEndNotificationCount;
        }
        public int Days { get; set; }
        public int Count { get; set; }
    }
}
