using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
