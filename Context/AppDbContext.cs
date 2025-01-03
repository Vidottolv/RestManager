using RestManager.Models;
using Microsoft.EntityFrameworkCore;

namespace RestManager.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "lucasvidotto12@gmail.com",
                    Nome = "Lucas Vidotto",
                    Idade = 22
                } ,
                new User
                {
                    Id = 2,
                    Email = "Vitoriadalsantofarinelli@gmail.com",
                    Nome = "Vitoria Farinelli",
                    Idade = 21
                }
                );
        }
    }
}
