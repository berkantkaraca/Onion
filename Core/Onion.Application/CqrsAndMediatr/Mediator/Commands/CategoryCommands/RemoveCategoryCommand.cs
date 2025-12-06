using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
