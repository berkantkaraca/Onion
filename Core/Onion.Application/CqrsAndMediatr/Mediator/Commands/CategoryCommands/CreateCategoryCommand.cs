using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
