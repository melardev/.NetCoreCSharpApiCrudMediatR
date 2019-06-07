using System.Collections.Generic;
using ApiMediatorDemo.Entities;
using MediatR;

namespace ApiMediatorDemo.Commands
{
    public class GetTodosCommand : IRequest<List<Todo>>
    {
        public bool? Completed { get; set; }
    }
}
