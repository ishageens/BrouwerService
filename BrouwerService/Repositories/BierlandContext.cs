using Microsoft.EntityFrameworkCore;
using BrouwerService.Models;

namespace BrouwerService.Repositories
{
    public class BierlandContext : DbContext
    {
        public BierlandContext(DbContextOptions<BierlandContext> options) : base(options) { }
        public DbSet<Brouwer> Brouwers { get; set; }
    }
}