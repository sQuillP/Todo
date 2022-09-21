namespace Todo.Models.DTO
{
    public class CreateTodo
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public bool Completed { get; set; }
    }
}
