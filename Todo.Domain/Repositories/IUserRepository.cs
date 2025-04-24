using Todo.Domain.Models;

namespace Todo.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByName(string name);
    }
}
