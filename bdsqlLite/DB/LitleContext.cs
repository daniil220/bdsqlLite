using Microsoft.EntityFrameworkCore;


namespace SQLlitleForIS_19_03.DB
{
    public class LitleContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }

        public LitleContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");
        }
    }
}
