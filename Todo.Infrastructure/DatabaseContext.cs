using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Infrastructure.Mappings;

namespace Todo.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TodoList> Todos { get; set; } = null!;
        public DbSet<TodoTask> Tasks { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TodoListMapping());
            modelBuilder.ApplyConfiguration(new TodoTaskMapping());
        }
    }
}
