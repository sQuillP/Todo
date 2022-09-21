namespace Todo.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public bool Completed { get; set; }

    }
}
