using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Employees.Queries
{
    public class GetEmployeeSelectListQuery : IRequest<SelectList>
    {
        public GetEmployeeSelectListQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
