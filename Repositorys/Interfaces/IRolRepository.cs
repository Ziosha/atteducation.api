using atteducation.api.Models;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface IRolRepository
    {
         Task<List<Rol>> GetRols();
    }
}