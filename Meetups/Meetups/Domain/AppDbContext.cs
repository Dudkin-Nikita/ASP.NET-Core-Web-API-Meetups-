using Meetups.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetups.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Meetup> Meetups { get; set; }
    }
}
