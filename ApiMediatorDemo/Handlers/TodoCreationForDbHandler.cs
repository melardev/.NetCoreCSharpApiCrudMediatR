using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Entities;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    public class TodoCreationForDbHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public TodoCreationForDbHandler(TodoService todoService)
        {
            this._todoService = todoService;
        }

        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            Todo todo = new Todo {Title = request.Title, Description = request.Description};
            await _todoService.CreateTodo(todo);
            Debug.WriteLine("Todo added successfully");
            return todo;
        }
    }
}