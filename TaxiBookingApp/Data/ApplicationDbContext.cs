using Microsoft.EntityFrameworkCore;
using TaxiBookingApp.Models;

namespace TaxiBookingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Driver> Drivers { get; set; }
    }
}
