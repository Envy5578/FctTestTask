using FctTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FctTestTask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        internal DbSet<LinkEntity> Links { get; set; }
    }
}
