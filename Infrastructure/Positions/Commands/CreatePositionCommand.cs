using System.ComponentModel.DataAnnotations;
using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Positions.Commands
{
    public class CreatePositionCommand : IRequest<OperationResult<int>>
    {
        [MaxLength(255), Required]
        [Remote(controller: "Positions", action: "CheckPositionExists", areaName: "Panel")]
        public string Name { get; set; }
    }
}
