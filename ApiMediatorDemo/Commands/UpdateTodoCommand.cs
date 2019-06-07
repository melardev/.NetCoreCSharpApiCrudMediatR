using ApiMediatorDemo.Entities;
using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class UpdateTodoCommand : IRequest<Todo>
    {
        public Todo TodoFromDb { get; set; }
        public Todo UpdatedTodo { get; set; }
    }
}
