using Microsoft.EntityFrameworkCore;
using Todo.Data;

namespace Todo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDBContext todoDb;


        public TodoRepository(TodoDBContext todoDb)
        {
            this.todoDb = todoDb;
        }

        public async Task<Models.Domain.Todo> CreateTodoAsync(Models.Domain.Todo todo)
        {
            todo.Id = Guid.NewGuid();
            await todoDb.AddAsync(todo);
            await todoDb.SaveChangesAsync();
            return todo;
        }

        public async Task<Models.Domain.Todo> DeleteTodoAsync(Guid id)
        {
            var todo = await todoDb.Todo.FirstOrDefaultAsync(
                todo => todo.Id == id
               );
            if(todo == null)
            {
                return todo;
            }
            todoDb.Todo.Remove(todo);
            await todoDb.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<Models.Domain.Todo>> GetAllTodosAsync()
        {
            var foundTodo = await todoDb.Todo.ToListAsync();
            return foundTodo;
        }

        public async Task<Models.Domain.Todo> GetTodoAsync(Guid id)
        {
            var foundTodo = await todoDb.Todo.FirstOrDefaultAsync(
                todo => todo.Id == id
                );
            return foundTodo;
        }

        public async Task<Models.Domain.Todo> UpdateTodoAsync(Guid id, Models.Domain.Todo update)
        {
            var foundTodo = await todoDb.Todo.FirstOrDefaultAsync(
                todo => todo.Id == id
                );
            if(foundTodo == null)
            {
                return foundTodo;
            }
            foundTodo.Completed = update.Completed;
            foundTodo.Content = update.Content;

            await todoDb.SaveChangesAsync();
            return foundTodo;
        }
    }
}
