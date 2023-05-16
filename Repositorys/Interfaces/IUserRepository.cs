using atteducation.api.Models;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface IUserRepository
    {
         Task<List<User>> GetUser();
         Task<User> GetUserById(int id);
    }
}