using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
