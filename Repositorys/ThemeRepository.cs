using atteducation.api.Data;
using atteducation.api.Dtos.ThemeDto;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Repositorys
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly DataContext _context;

        public ThemeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Theme>> GetThemes(int contentId)
        {
            var themes = await _context.Themes.Where(x => x.ContentId == contentId).ToListAsync();
            return themes;
        }

        public async Task<Theme> CreateThem(CreateThemDto create)
        {
            var theme = new Theme()
            {
                ThemeName = create.ThemeName,
                Description = create.Description,
                ContentId = create.ContentId
            };

            await _context.Themes.AddAsync(theme);
            await _context.SaveChangesAsync();

            return theme;
        }
        
    }
}