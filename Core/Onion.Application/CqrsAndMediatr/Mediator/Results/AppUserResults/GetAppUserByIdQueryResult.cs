namespace Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults
{
    public class GetAppUserByIdQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
