using atteducation.api.Models;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface IThemeRepository
    {
         Task<List<Theme>> GetThemes(int contentId);
    }
}