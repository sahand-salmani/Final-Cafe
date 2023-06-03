using MediatR;

namespace Infrastructure.Positions.Queries
{
    public class CheckPositionExistsQuery : IRequest<bool>
    {
        public CheckPositionExistsQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
