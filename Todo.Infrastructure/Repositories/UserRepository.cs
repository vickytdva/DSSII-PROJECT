using System.Text.Json.Serialization;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int? Create(User entity)
        {
            _databaseContext.Set<User>().Add(entity);
            _databaseContext.SaveChanges(); // Save to the database
            return entity.Id;
        }

        public void Delete(User entity)
        {
            _databaseContext.Set<User>().Remove(entity);
            _databaseContext.SaveChanges(); // Save after delete
        }

        public IEnumerable<User> GetAll()
        {
            return _databaseContext.Set<User>().AsQueryable().ToList();
        }

        public User? GetById(int id)
        {
            return _databaseContext.Set<User>().FirstOrDefault(e => e.Id == id);
        }

        public async Task<User?> GetByName(string name)
        {
            return await _databaseContext.Set<User>().FirstOrDefaultAsync(e => e.Name == name);
        }

        public void Update(User entity)
        {
            _databaseContext.Update(entity);
            _databaseContext.SaveChanges(); // Save after update
        }
    }
}
