using FA_1.Models;
using Microsoft.EntityFrameworkCore;

namespace FA_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}