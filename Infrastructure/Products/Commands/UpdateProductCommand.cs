using Infrastructure.Common;
using Infrastructure.Products.ViewModels;
using MediatR;

namespace Infrastructure.Products.Commands
{
    public class UpdateProductCommand : IRequest<OperationResult<GetProductVm>>
    {
        public UpdateProductCommand(int id, UpdateProductVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public UpdateProductVm Model { get; set; }
    }
}
