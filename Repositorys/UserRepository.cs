using atteducation.api.Data;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<User>> GetUser()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
         
    }
}