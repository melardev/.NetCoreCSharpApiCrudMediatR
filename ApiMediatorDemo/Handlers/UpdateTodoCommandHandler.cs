using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Entities;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public UpdateTodoCommandHandler(TodoService todoService)
        {
            this._todoService = todoService;
        }

        public async Task<Todo> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            return await _todoService.Update(request.TodoFromDb, request.UpdatedTodo);
        }
    }
}