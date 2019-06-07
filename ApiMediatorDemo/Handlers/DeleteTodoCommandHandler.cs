using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly TodoService _todoService;

        public DeleteTodoCommandHandler(TodoService todoService)
        {
            this._todoService = todoService;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _todoService.Delete(request.Id);
            return true;
        }
    }
}