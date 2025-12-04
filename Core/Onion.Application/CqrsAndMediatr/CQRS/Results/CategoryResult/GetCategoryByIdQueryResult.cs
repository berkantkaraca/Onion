namespace Onion.Application.CqrsAndMediatr.CQRS.Results.CategoryResult
{
    public class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
