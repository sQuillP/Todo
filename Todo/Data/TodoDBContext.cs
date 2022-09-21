using Microsoft.EntityFrameworkCore;


namespace Todo.Data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }

        // List out db tables to create
        public DbSet<Models.Domain.Todo> Todo { get; set; }
    }
}
