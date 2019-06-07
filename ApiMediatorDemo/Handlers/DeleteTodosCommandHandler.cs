using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    public class DeleteTodosCommandHandler : IRequestHandler<DeleteAllTodosCommand, bool>
    {
        private readonly TodoService _todoService;

        public DeleteTodosCommandHandler(TodoService todoService)
        {
            this._todoService = todoService;
        }

        public async Task<bool> Handle(DeleteAllTodosCommand request, CancellationToken cancellationToken)
        {
            await _todoService.DeleteAll();
            return true;
        }
    }
}