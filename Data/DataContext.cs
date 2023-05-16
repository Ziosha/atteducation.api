using atteducation.api.Models;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        DbSet<User> Users { get; set;}
        DbSet<Rol> Rols { get; set; }
        DbSet<UserRols> UserRols { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<UserRols>()
            //     .HasOne(u => u.User)
            //     .WithMany(us => us.UserRols)
            //     .OnDelete(DeleteBehavior.Restrict);
            
            // builder.Entity<UserRols>()
            //     .HasOne(u => u.Rol)
            //     .WithMany(us => us.UserRols)
            //     .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}