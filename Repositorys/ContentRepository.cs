using atteducation.api.Data;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Repositorys
{
    public class ContentRepository : IContentRepository
    {
        private readonly DataContext _context;

        public ContentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Content>> getContent()
        {
            var Content = await _context.Contents.ToListAsync();
            return Content;
        }

        public async Task<Content> getContentById(int contetnId)
        {
            var Content = await _context.Contents.FirstOrDefaultAsync(x => x.Id == contetnId);
            return Content;
        }
    }
}