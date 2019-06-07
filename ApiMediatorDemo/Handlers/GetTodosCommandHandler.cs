using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Entities;
using ApiMediatorDemo.Enums;
using ApiMediatorDemo.Infrastructure.Services;
using MediatR;

namespace ApiMediatorDemo.Handlers
{
    public class GetTodosCommandHandler : IRequestHandler<GetTodosCommand, List<Todo>>
    {
        private readonly TodoService _todoService;

        public GetTodosCommandHandler(TodoService todosService)
        {
            _todoService = todosService;
        }

        public async Task<List<Todo>> Handle(GetTodosCommand request, CancellationToken cancellationToken)
        {
            TodoShow which;

            if (request.Completed != null && request.Completed.Value)
                which = TodoShow.Completed;
            else if (request.Completed != null && !request.Completed.Value)
                which = TodoShow.Pending;
            else
                which = TodoShow.All;

            return await _todoService.FetchMany(which);
        }
    }
}