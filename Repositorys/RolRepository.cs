using atteducation.api.Data;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Repositorys
{
    public class RolRepository : IRolRepository
    {
        private readonly DataContext _context;

        public async Task<List<Rol>> GetRols()
        {
            var rols = await _context.Rols.ToListAsync();
            return rols;
        }
    }
}