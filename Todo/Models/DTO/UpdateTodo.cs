﻿namespace Todo.Models.DTO
{
    public class UpdateTodo
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public bool Completed { get;set; }
    }
}
