using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Service.Interfaces
{
    public interface IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        Task<int> SaveChangesAsync();
    }
}
