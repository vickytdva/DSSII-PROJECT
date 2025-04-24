using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TodoTaskRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int? Create(TodoTask entity)
        {
            _databaseContext.Set<TodoTask>().Add(entity);
            _databaseContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(TodoTask entity)
        {
            _databaseContext.Set<TodoTask>().Remove(entity);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _databaseContext.Set<TodoTask>()
                .Include(e => e.Holder)
                .AsQueryable()
                .ToList();
        }

        public TodoTask? GetById(int id)
        {
            return _databaseContext.Set<TodoTask>()
                .Include(e => e.Holder)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(TodoTask entity)
        {
            _databaseContext.Update(entity);
            _databaseContext.SaveChanges();
        }
    }
} 