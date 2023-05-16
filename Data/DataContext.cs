using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        
    }
}