using Microsoft.EntityFrameworkCore;

namespace GameStore.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {

        }
        public DbSet<Game> Games { get; set; }
    }
}
