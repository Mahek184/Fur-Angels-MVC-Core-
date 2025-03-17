using FurAngels.Models;
using Microsoft.EntityFrameworkCore;

namespace FurAngels.Data
{
    public class FurAngelsDbContext : DbContext
    {
        public FurAngelsDbContext(DbContextOptions<FurAngelsDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}