using Microsoft.AspNetCore.Mvc;
using Todo.Repositories;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await todoRepository.GetAllTodosAsync();
            return Ok(todos);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodo([FromRoute] Guid id)
        {
            var todo = await todoRepository.GetTodoAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Models.DTO.CreateTodo todo)
        {

            //Map the DTO to the domain
            var domainTodo = new Models.Domain.Todo()
            {
                Completed = todo.Completed,
                Content = todo.Content
            };

            var createdTodo = await todoRepository.CreateTodoAsync(domainTodo);

            return Ok(createdTodo);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute]Guid id, [FromBody] Models.DTO.UpdateTodo update)
        {
            //Convert to domain to perform update.
            var todoDomain = new Models.Domain.Todo()
            {
                Completed = update.Completed,
                Content = update.Content
            };

            var updatedTodo = await todoRepository.UpdateTodoAsync(id, todoDomain);


            if(updatedTodo == null)
            {
                return NotFound();
            }

            //Convert back to DTO to send to client
            var todoDTO = new Models.DTO.UpdateTodo()
            {
                Completed = updatedTodo.Completed,
                Content = updatedTodo.Content

            };
            return Ok(updatedTodo);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute]Guid id)
        {
            var deletedTodo = await todoRepository.DeleteTodoAsync(id);

            if(deletedTodo == null)
            {
                return NotFound();
            }
            return Ok(deletedTodo);
        }
    }
}
