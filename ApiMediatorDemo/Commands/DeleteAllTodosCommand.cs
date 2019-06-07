using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class DeleteAllTodosCommand : IRequest<bool>
    {
    }
}
