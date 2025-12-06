using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<GetCategoryByIdQueryResult>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
