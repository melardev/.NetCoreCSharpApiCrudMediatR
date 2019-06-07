using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}