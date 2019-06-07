using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Entities;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    // This handler handles GetTodoCommand and returns a Task<Todo>
    public class GetTodoCommandHandler : IRequestHandler<GetTodoCommand, Todo>
    {
        private readonly TodoService _todoService;

        public GetTodoCommandHandler(TodoService todoService)
        {
            this._todoService = todoService;
        }

        public async Task<Todo> Handle(GetTodoCommand request, CancellationToken cancellationToken)
        {
            return await _todoService.GetById((int) request.Id);
        }
    }
}