using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    //Todo: Ödev
    //Burada geriye değer döndüreceği zaman Result altında onlara CommandResultlar oluşturulup IRequeste generic olarak eklenir
    public class CreateAppUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
