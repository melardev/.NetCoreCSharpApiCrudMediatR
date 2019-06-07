using ApiMediatorDemo.Entities;
using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class GetTodoCommand : IRequest<Todo>
    {
        public long Id { get; set; }
    }
}