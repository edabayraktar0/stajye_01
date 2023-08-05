using Microsoft.EntityFrameworkCore;

namespace proje_01.Models

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<kisi> kisis { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
