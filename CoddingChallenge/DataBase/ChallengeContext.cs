using CoddingChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.DataBase
{
    public class ChallengeContext:DbContext
    {
        public DbSet<User>users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS; Initial Catalog=CoddingchallengeDB;User Id= kotesh;Password=Kolli@123;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
