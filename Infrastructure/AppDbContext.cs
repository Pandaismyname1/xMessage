using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuthKey> AuthKeys { get; set; }
        public DbSet<ContactLinkage> ContactLinkages { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<BinaryMessage> BinaryMessages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionInitializer.LoadFromFile("MySQLConnection.json");
            optionsBuilder.UseMySql($"Server={SqlConnectionInitializer.SQLConnection.Url};Database={SqlConnectionInitializer.SQLConnection.Database};User={SqlConnectionInitializer.SQLConnection.User};Password={SqlConnectionInitializer.SQLConnection.Password};");
        }
    }
}
