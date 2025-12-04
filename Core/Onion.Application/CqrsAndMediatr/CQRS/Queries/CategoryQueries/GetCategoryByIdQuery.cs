namespace Onion.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
