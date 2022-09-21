
namespace Todo.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Models.Domain.Todo>> GetAllTodosAsync();

        Task<Models.Domain.Todo> GetTodoAsync(Guid id);

        Task<Models.Domain.Todo> UpdateTodoAsync(Guid id, Models.Domain.Todo update);

        Task<Models.Domain.Todo> DeleteTodoAsync(Guid id);

        Task<Models.Domain.Todo> CreateTodoAsync(Models.Domain.Todo todo);

    }
}
