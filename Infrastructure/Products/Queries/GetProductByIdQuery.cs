using Infrastructure.Products.ViewModels;
using MediatR;

namespace Infrastructure.Products.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductVm>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
