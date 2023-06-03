using MediatR;

namespace Infrastructure.UserToken.Queries
{
    public class CheckTokenExistsQuery : IRequest<bool>
    {
        public CheckTokenExistsQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
