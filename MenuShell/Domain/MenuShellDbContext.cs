using System.Data.Entity;

namespace MenuShell.Domain
{
    internal class MenuShellDbContext : DbContext
    {
        public MenuShellDbContext() : base("MenuShellDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}