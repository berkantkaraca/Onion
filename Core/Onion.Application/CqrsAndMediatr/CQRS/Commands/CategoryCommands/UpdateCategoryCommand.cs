namespace Onion.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
