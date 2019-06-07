using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ApiMediatorDemo.Commands;
using ApiMediatorDemo.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiMediatorDemo.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            List<Todo> todos = await _mediator.Send(new GetTodosCommand());
            return new OkObjectResult(todos);
        }

        [HttpGet]
        [Route("pending")]
        public async Task<IActionResult> GetPending([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            List<Todo> todos = await _mediator.Send(new GetTodosCommand {Completed = false});
            return Ok(todos);
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompleted([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            List<Todo> todos = await _mediator.Send(new GetTodosCommand {Completed = true});
            return StatusCode((int) HttpStatusCode.OK, Json(todos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodoDetails(int id)
        {
            var todo = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todo == null)
            {
                // return StatusCode((int) HttpStatusCode.NotFound, new ErrorDtoResponse("Not found"));
                return StatusCode((int) HttpStatusCode.NotFound, new JsonResult(new
                {
                    Success = false,
                    FullMessages = new string[]
                    {
                        "Not Found"
                    }
                }));
            }
            else
                return Json(todo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            CreateTodoCommand command = new CreateTodoCommand
            {
                Title = todo.Title,
                Description = todo.Description
            };

            Todo persistedTodo = _mediator.Send(command).Result;

            var response = new ObjectResult(persistedTodo);
            response.StatusCode = (int) HttpStatusCode.Created;
            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo todo)
        {
            var todoFromDb = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todoFromDb == null)
                return NotFound(Json(new
                {
                    Success = false,
                    FullMessages = new string[]
                    {
                        "Not Found"
                    }
                }));
            else
            {
                Todo updatedTodo = await _mediator.Send(new UpdateTodoCommand
                    {TodoFromDb = todoFromDb, UpdatedTodo = todo});

                return new OkObjectResult(updatedTodo);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todoFromDb = await _mediator.Send(new GetTodoCommand {Id = id});
            if (todoFromDb == null)
                return new NotFoundObjectResult(Json(new
                {
                    Success = false,
                    FullMessages = new string[]
                    {
                        "Not Found"
                    }
                }));
            else
            {
                bool result = await _mediator.Send(new DeleteTodoCommand {Id = id});
            }

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            bool success = await _mediator.Send(new DeleteAllTodosCommand());
            return new NoContentResult();
        }
    }
}