using atteducation.api.Dtos.ThemeDto;
using atteducation.api.Models;
namespace atteducation.api.Repositorys.Interfaces
{
    public interface IThemeRepository
    {
         Task<Theme> CreateThem(CreateThemDto create);
         Task<List<Theme>> getTheme();
         Task<Theme> getThemeById(int contetnId);
    }
}