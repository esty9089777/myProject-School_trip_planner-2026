using myProjectTrips.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace myProjectTrips.model
{
    public class TripContext : DbContext, IContext
    {
        public TripContext() { }

        public TripContext(DbContextOptions<TripContext> options):base(options)
        {
        }

        private readonly string? _connectionString;
        public TripContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public async Task Save()
        {
            await SaveChangesAsync();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branch>()
                .HasIndex(b => b.BranchName);

            modelBuilder.Entity<Branch>()
                .HasIndex(b => b.direction);

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.BranchId);

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.RouteId);

            modelBuilder.Entity<Availability>()
                .HasIndex(a => a.BranchId);

            modelBuilder.Entity<Availability>()
                .HasIndex(a => a.RouteId);

            modelBuilder.Entity<Availability>()
                .HasIndex(a => a.Day);

        }
    }
}
