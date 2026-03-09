using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace myProjectTrips.model
{
    public class TripContextFactory : IDesignTimeDbContextFactory<TripContext>
    {
        public TripContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TripContext>();

            optionsBuilder.UseSqlServer(
                "Server=.;Database=MyProjectTripsDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new TripContext(optionsBuilder.Options);
        }
    }
}
