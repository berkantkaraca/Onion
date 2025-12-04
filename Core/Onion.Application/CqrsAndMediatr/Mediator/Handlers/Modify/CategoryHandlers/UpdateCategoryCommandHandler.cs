using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);

            value.CategoryName = request.CategoryName;
            value.Description = request.Description;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}
