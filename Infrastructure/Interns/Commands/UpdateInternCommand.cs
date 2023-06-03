using Infrastructure.Common;
using Infrastructure.Interns.ViewModels;
using MediatR;

namespace Infrastructure.Interns.Commands
{
    public class UpdateInternCommand :IRequest<OperationResult<GetInternVm>>
    {
        public int Id { get; set; }
        public GetInternVm GetInternVm { get; set; }
        private UpdateInternCommand(int id, GetInternVm model)
        {
            Id = id;
            GetInternVm = model;
        }

        public static UpdateInternCommand Update(int id, GetInternVm model) => new UpdateInternCommand(id, model);
    }
}
