using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Fails.Commands
{
    public class CreateFailCommand : IRequest<OperationResult<int>>
    {
        public int EmployeeId { get; set; }
        [MaxLength(255)]
        public string Restaurant { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime HappenedAt { get; set; }
        public SelectList SelectList { get; set; }
    }
}
