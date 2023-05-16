using atteducation.api.Models;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<User> Users { get; set;}
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserRols> UserRols { get; set;}
        //porfavorfunca
        public DbSet<Coment> Coments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ComentContent> ComentContents { get; set; }
        public DbSet<UserContent> UserContents { get; set; }

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