using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TodoListRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int? Create(TodoList entity)
        {
            _databaseContext.Set<TodoList>().Add(entity);
            _databaseContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(TodoList entity)
        {
            _databaseContext.Set<TodoList>().Remove(entity);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _databaseContext.Set<TodoList>()
                .Include(e => e.Tasks)
                .AsQueryable()
                .ToList();
        }

        public TodoList? GetById(int id)
        {
            return _databaseContext.Set<TodoList>()
                .Include(e => e.Tasks)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(TodoList entity)
        {
            _databaseContext.Update(entity);
            _databaseContext.SaveChanges();
        }
    }
} 