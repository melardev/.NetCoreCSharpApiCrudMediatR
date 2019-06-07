using ApiMediatorDemo.Entities;
using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class CreateTodoCommand : IRequest<Todo>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}